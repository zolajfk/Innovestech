using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Composing;
using System.Web.Optimization;
using TSPadel_Umbraco.App_Start;

namespace TSPadel_Umbraco
{
    public class LoadBundles : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<BundleComponent>();
        }
    }

    public class BundleComponent : IComponent
    {

        public void Initialize()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void Terminate()
        {
        }
    }
}