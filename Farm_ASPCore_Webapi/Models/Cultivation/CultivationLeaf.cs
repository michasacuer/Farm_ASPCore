﻿using Farm_ASPCore_Webapi.Models.Enums;
using Farm_ASPCore_Webapi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farm_ASPCore_Webapi.Models
{
    public class CultivationLeaf : Cultivation, ISummary
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
                //Indexer--;
                var cultivationComposite = new CultivationComposite();
                CultivationLeaf leaf1 = new CultivationLeaf(cultivationComposite), leaf2 = new CultivationLeaf(cultivationComposite);
                leaf1.Acreage = Acreage * ratio;
                leaf2.Acreage = Acreage * (1 - ratio);
                cultivationComposite.Add(leaf1);
                cultivationComposite.Add(leaf2);
                return (leaf1, leaf2, cultivationComposite);
            }
        }

        public override void Sow(Grain grain)
        {
            if (Grain == Grain.None)
            {
                Grain = grain;
                Income = 0;
            }

            else
                return;
        }

        public override void Harvest()
        {
            if (Grain == Grain.None)
                return;

            Income += GetCost();
            Grain = Grain.None;
        }

        public double GetCost()
        {
            double price = Grain == Grain.Rice ? priceRice : 
                           Grain == Grain.Oats ? priceOats : priceCorn;

            return price * Acreage;
        }

        public override void Remove(Cultivation cultivation)  => throw new InvalidOperationException("Can't remove child components from leaf cultivation");
        public override void Add(Cultivation cultivation)     => throw new InvalidOperationException("Can't add child components to leaf cultivation");
        public override List<Cultivation> GetCompositeLeafs() => throw new InvalidOperationException("Leaf dont have list of leafs");

        private double priceRice = 100000;
        private double priceCorn = 200000;
        private double priceOats = 300000;
    }
}
