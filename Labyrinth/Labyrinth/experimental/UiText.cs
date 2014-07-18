using System.Text;
using Labyrinth.Renderer.Contracts;

namespace Labyrinth.Labyrinth.experimental
{
    public class UiText : EntityX, IUiTextX
    {
        private IRendererX renderer;
        private ILanguageStrings dialogList;
        private string textField;

        public UiText(IntPointX coords, IRendererX renderer, ILanguageStrings dialogList)
            : base(coords)
        {
            this.renderer = renderer;
            this.dialogList = dialogList;
            this.textField = "";
        }

        public void SetText(string input, string[] args)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(this.dialogList.GetDialog(input), args);

            this.textField = sb.ToString();
        }
        public void SetText(string input, bool isKey)
        {
            if (isKey)
            {
                this.textField = this.dialogList.GetDialog(input);
            }
            else
            {
                this.textField = input;
            }
        }
        public void SetText(string input)
        {
            this.SetText(input, false);
        }

        public void Clear()
        {
            this.textField = "";
        }

        override public void Render()
        {
            this.renderer.RenderEntity(this);
        }

        public override string ToString()
        {
            return this.textField;
        }
    }
}
