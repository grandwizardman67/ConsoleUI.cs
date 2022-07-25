using System;
using System.Threading;

namespace Renderer
{
    public class Program
    {
        public static void Main()
        {
            Console.Clear();
            Thread inputThread = new Thread(Input.GetInput);
            inputThread.Start();
            Label s = new Label("Hello, World!");
            ProgressBar p = new ProgressBar(3, 7);
            CheckBox cb = new CheckBox("Check me!", false);
            Button button = new Button("Click me!", delegate {s.text = "You clicked the button!";});

            Renderer.Render(s, new Vector2(0, 0));
            Renderer.Render(p, new Vector2(2, 1));
            Renderer.Render(cb, new Vector2(4, 2));
            Renderer.Render(button, new Vector2(6, 3));
        }
    }
}