using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using PEPlugin;
using PEPlugin.Form;
using PEPlugin.Pmd;
using PEPlugin.Pmx;
using PEPlugin.SDX;
using PEPlugin.View;
using PEPlugin.Vmd;
using PEPlugin.Vme;

namespace Aroima.Plugins.Skirt
{
    public class SkirtPlugin : PEPluginClass
    {

        IPEPluginHost host;
        IPEBuilder builder;
        IPEShortBuilder bd;
        IPEConnector connect;
        IPEXPmd pex;
        IPXPmx pmx;
        IPEPmd pmd;
        IPEFormConnector formConnector;
        IPXPmxViewConnector pmxView;
        IPEPMDViewConnector pmdView;

        //SkirtForm form = null;

        public SkirtPlugin() : base()
        {
            m_option = new PEPluginOption(false, true, "Aroima.SkirtPlugin");
        }

        public IPEPluginHost Host { get => host; set => host = value; }
        public IPEBuilder Builder { get => builder; set => builder = value; }
        public IPEShortBuilder Bd { get => bd; set => bd = value; }
        public IPEConnector Connect { get => connect; set => connect = value; }
        public IPEXPmd Pex { get => pex; }
        public IPXPmx PMX { get => pmx; }
        public IPEPmd PMD { get => pmd; }
        public IPEFormConnector FormConnector { get => formConnector; set => formConnector = value; }
        public IPXPmxViewConnector PmxView { get => pmxView; set => pmxView = value; }
        public IPEPMDViewConnector PmdView { get => pmdView; set => pmdView = value; }

        public override void Run(IPERunArgs args)
        {
            host = args.Host;
            builder = args.Host.Builder;
            bd = args.Host.Builder.SC;
            connect = args.Host.Connector;
            pex = connect.Pmd.GetCurrentStateEx();
            pmd = connect.Pmd.GetCurrentState();
            pmx = connect.Pmx.GetCurrentState();
            formConnector = connect.Form;
            pmxView = connect.View.PmxView;
            pmdView = connect.View.PMDView;

            /*
            if (form == null)
            {
                form = new SkirtForm();
                form.Plugin = this;
                form.FormClosed += Form_FormClosed;
            }
            form.Visible = true;
            */
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            //form = null;
        }

        public void UpdateView()
        {
            this.connect.Pmx.Update(this.PMX);
            this.connect.Form.UpdateList(UpdateObject.All);
            this.connect.View.PMDView.UpdateModel();
            this.connect.View.PMDView.UpdateView();
        }

    }
}
