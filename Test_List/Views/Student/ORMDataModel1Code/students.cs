using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace Test_List.Views.Student.ORMDataModel1
{

    public partial class students
    {
        public students(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
