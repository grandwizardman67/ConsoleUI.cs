using System;

namespace Renderer
{
    public class GroupBox : IRenderable
    {
        public string Text;
        public Panel Panel;
        Vector2 _Position;
        public Vector2 Position { get { return _Position; } set { if(_Position != null) DeRender(); _Position = value; } }
                bool _Visible = true;
        public bool Selected { get; set; }
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

        public GroupBox(string text, Panel panel)
        {
            this.Text = text;
            this.Panel = panel;
        }

        public void Render()
        {
            Panel.Position = Position;
            Console.SetCursorPosition(Position.x, Position.y);
            Panel.Render();
            Console.SetCursorPosition(Position.x+2, Position.y);
            Console.Write(Text);
        }

        public void DeRender()
        {
            Panel.DeRender();
        }

        public void ReRender()
        {
            DeRender();
            Console.SetCursorPosition(Position.x, Position.y);
            Render();
        }
    }
}