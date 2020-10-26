using System;
using DB = Autodesk.Revit.DB;

namespace RhinoInside.Revit.GH.Types
{
  public class FillPatternElement : Element
  {
    public override string TypeName => "Revit Fill Pattern";
    public override string TypeDescription => "Represents a Revit Fill Pattern Element";
    protected override Type ScriptVariableType => typeof(DB.FillPatternElement);
    public new DB.FillPatternElement Value => base.Value as DB.FillPatternElement;
    public static explicit operator DB.FillPatternElement(FillPatternElement value) => value?.Value;

    public FillPatternElement() { }
    public FillPatternElement(DB.Document doc, DB.ElementId id) : base(doc, id) { }
    public FillPatternElement(DB.FillPatternElement value) : base(value) { }
  }
}
