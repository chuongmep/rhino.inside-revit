using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Parameters;

using DB = Autodesk.Revit.DB;
using RhinoInside.Revit.External.DB;
using RhinoInside.Revit.GH.Components.Element.Material;

namespace RhinoInside.Revit.GH.Components
{
#if REVIT_2019
  public abstract class ConstructTextureAsset<T>
    : BaseAssetComponent<T> where T : TextureData, new()
  {
    public override GH_Exposure Exposure => GH_Exposure.senary;

    public ConstructTextureAsset() : base()
    {
      Name = $"Construct {ComponentInfo.Name}";
      NickName = $"C-{ComponentInfo.NickName}";
      Description = $"Construct {ComponentInfo.Description}";
    }

    protected override ParamDefinition[] Inputs => GetAssetDataAsInputs();
    protected override ParamDefinition[] Outputs => new ParamDefinition[]
    {
      ParamDefinition.Create<Parameters.TextureData>(
        name: ComponentInfo.Name,
        nickname: ComponentInfo.NickName,
        description: ComponentInfo.Description,
        access: GH_ParamAccess.item
        ),
    };

    protected override void TrySolveInstance(IGH_DataAccess DA)
      => DA.SetData(
        ComponentInfo.Name,
        new Types.TextureData(CreateAssetDataFromInputs(DA))
        );
  }

  public class ConstructBitmapTexture
    : ConstructTextureAsset<UnifiedBitmapData>
  {
    public override Guid ComponentGuid
      => new Guid("37b63660-c083-45e3-9b98-cfdd2b539055");
  }

  public class ConstructCheckerTexture
    : ConstructTextureAsset<CheckerData>
  {
    public override Guid ComponentGuid
      => new Guid("2332c031-de18-43a9-b41f-6405e1460c06");
  }
#endif
}