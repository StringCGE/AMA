﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using FundacionAMA.Domain.Shared.Entities;

using System;
using System.Collections.Generic;

namespace FundacionAMA.Domain.Entities;

public partial class ConsultVolunteer: BaseEntity
{
    public int Consult { get; set; }

    public int? VolunteerId { get; set; }

    public virtual RegistrationVolunteer Volunteer { get; set; }
}