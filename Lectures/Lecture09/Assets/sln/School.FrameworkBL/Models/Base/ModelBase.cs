using System;
using GalaSoft.MvvmLight;

namespace School.FrameworkBL.Models.Base
{
    public class ModelBase : ObservableObject, IModel
    {
        public Guid Id { get; set; }
    }
}