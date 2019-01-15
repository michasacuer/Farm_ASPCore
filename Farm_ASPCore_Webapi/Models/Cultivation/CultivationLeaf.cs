using Farm_ASPCore_Webapi.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farm_ASPCore_Webapi.Models
{
    public class CultivationLeaf : Cultivation
    {
        public Cultivation Parent { get; set; }
        public double Acreage { get; set; } = 5D;

        public CultivationLeaf() { }
        public CultivationLeaf(Cultivation parent)
        {
            Grain = Grain.None;
            Parent = parent;
        }

        public override (Cultivation, Cultivation, Cultivation) Split(double ratio)
        {
            if (Parent != null)
            {
                CultivationLeaf leaf1 = new CultivationLeaf(Parent), leaf2 = new CultivationLeaf(Parent);
                leaf1.Acreage = Acreage * ratio;
                leaf2.Acreage = Acreage * (1 - ratio);
                Parent.Add(leaf1);
                Parent.Add(leaf2);
                Parent.Remove(this);
                return (leaf1, leaf2, Parent);
            }
            else
            {
                var cultivationComposite = new CultivationComposite();
                CultivationLeaf leaf1 = new CultivationLeaf(cultivationComposite), leaf2 = new CultivationLeaf(cultivationComposite);
                leaf1.Acreage = Acreage * ratio;
                leaf2.Acreage = Acreage * (1 - ratio);
                cultivationComposite.Add(leaf1);
                cultivationComposite.Add(leaf2);
                return (leaf1, leaf2, cultivationComposite);
            }
        }

        public override void Harvest()        => Grain = Grain.None;
        public override void Sow(Grain grain) => Grain = grain;

        public override void Remove(Cultivation cultivation) => throw new InvalidOperationException("Can't remove child components from leaf cultivation");
        public override void Add(Cultivation cultivation)    => throw new InvalidOperationException("Can't add child components to leaf cultivation");
    }
}
