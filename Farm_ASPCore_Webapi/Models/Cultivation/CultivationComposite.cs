﻿using Farm_ASPCore_Webapi.Models.Enums;
using System;
using System.Collections.Generic;


namespace Farm_ASPCore_Webapi.Models
{
    public class CultivationComposite : Cultivation
    {
        public CultivationComposite() => cultivations = new List<Cultivation>();

        public override (Cultivation, Cultivation, Cultivation) Split(double ratio) => throw new InvalidOperationException("Splitting group unsupported");
        public override void Harvest()                                              => cultivations.ForEach(c => c.Harvest());
        public override void Add(Cultivation cultivation)                           => cultivations.Add(cultivation);
        public override void Remove(Cultivation cultivation)                        => cultivations.Remove(cultivation);
        public override void Sow(Grain grain)                                       => cultivations.ForEach(c => c.Sow(grain));
        public override List<Cultivation> GetCompositeLeafs()                       => cultivations;

        private List<Cultivation> cultivations;
    }
}
