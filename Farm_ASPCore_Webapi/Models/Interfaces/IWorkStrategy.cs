﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Farm_ASPCore_Webapi.Models.Interfaces
{   
    public interface IWorkStrategy
    {
        int TimeOfWork();
    }
}
