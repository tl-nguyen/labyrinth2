using System.Text;
using Labyrinth.Commons;
using Labyrinth.UI.Contracts;
using Labyrinth.Renderer.Contracts;
using Labyrinth.Entities;

namespace Labyrinth.UI
{
    public class UiText : IUiText
    {
        public IntPoint TopLeft { get; set; }
        public dynamic Graphic { get; protected set; }

        private IRenderer renderer;
        private ILanguageStrings dialogList;
        private string textField;

        public UiText(IntPoint coords, IRenderer renderer, ILanguageStrings dialogList)
        {
            this.TopLeft = coords;
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

        public void Render()
        {
            this.UpdateGraphic();
            this.renderer.RenderEntity(this);
        }

        private void UpdateGraphic()
        {
            this.Graphic = this.textField;
        }

        public void SetX(int x)
        {
            this.TopLeft.X = x;
        }

        public void SetY(int y)
        {
            this.TopLeft.Y = y;
        }
    }
}
