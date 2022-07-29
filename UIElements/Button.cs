using System;

namespace Renderer
{
    public class Button : IInteractive
    {
        public Vector2 Position { get; set; }
        bool _Visible = true;
        public bool Visible 
        { 
            get { return _Visible; } 
            set 
            {
                _Visible = value;
                if (value)
                    Render();
                else
                    DeRender();
            } 
        }
        private string _Text;
        public string Text { get { return _Text; } set { _Text = value; ReRender(); } }
        private string previousString;
        public Action onClick { get; set; }

        string leftSide = "[";
        string rightSide = "]";

        public Button(string text, Action OnClick)
        {
            this._Text = text;
            this.onClick = OnClick;
        }
        public Button(string text, Action OnClick, string leftSide, string rightSide)
        {
            this._Text = text;
            this.onClick = OnClick;
            this.leftSide = leftSide;
            this.rightSide = rightSide;
        }

        public void Render()
        {
            string s = leftSide + " " + Text + " " + rightSide;
            previousString = UIElement.ParsePreviousString(s);
            Console.Write(s);
        }
        
        public void DeRender()
        {
            Console.SetCursorPosition(Position.x, Position.y);
            Console.Write(previousString);
        }

        public void ReRender()
        {
            DeRender();
            Console.SetCursorPosition((int)Position.x, (int)Position.y);
            Render();
        }

        public void OnHover() { }
        public void OnClick() { this.onClick(); }
        public void OnUpArrow() { }
        public void OnDownArrow() { }
        public void OnLeftArrow() { }
        public void OnRightArrow() { }
        public void OnHoverLeave() { }
        public void OnTextInput(ConsoleKeyInfo character) { }
    }
}