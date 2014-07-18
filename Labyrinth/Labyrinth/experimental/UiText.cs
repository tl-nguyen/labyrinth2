using System.Text;
using Labyrinth.Renderer.Contracts;

namespace Labyrinth.Labyrinth.experimental
{
    public class UiText : IUiTextX
    {
        public IntPointX TopLeft { get; set; }
        private IRendererX renderer;
        private ILanguageStrings dialogList;
        private string textField;

        public UiText(IntPointX coords, IRendererX renderer, ILanguageStrings dialogList)
        {
            this.TopLeft = coords;
            this.renderer = renderer;
            this.dialogList = dialogList;
            this.textField = "";
        }

        public void SetText(string key, string[] args)
        {
            StringBuilder sb = new StringBuilder();
            if (args != null)
            {
                sb.AppendFormat(this.dialogList.GetDialog(key), args);
            }
            else
            {
                sb.AppendFormat(this.dialogList.GetDialog(key));
            }
            this.textField = sb.ToString();
        }
        public void SetText(string key)
        {
            this.SetText(key, null);
        }

        public void Clear()
        {
            this.textField = "";
        }

        public void Render()
        {
            this.renderer.RenderEntity(this);
        }

        public override string ToString()
        {
            return this.textField;
        }
    }
}
