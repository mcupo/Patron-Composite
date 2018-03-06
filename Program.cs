using System;

using System.Collections.Generic;

namespace DoFactory.GangOfFour.Composite.RealWorld

{

    class MainApp

    {

        static void Main()

        {

            // Creo una estructura de arbol

            CompositeElement root = new CompositeElement("Picture");

            root.Add(new PrimitiveElement("Red Line"));

            root.Add(new PrimitiveElement("Blue Circle"));

            root.Add(new PrimitiveElement("Green Box"));

            // Agrego una rama

            CompositeElement comp = new CompositeElement("Two Circles");

            comp.Add(new PrimitiveElement("Black Circle"));

            comp.Add(new PrimitiveElement("White Circle"));

            root.Add(comp);

            // Agrego un elemento primitivo y lo elimino

            PrimitiveElement pe = new PrimitiveElement("Yellow Line");

            root.Add(pe);

            root.Display(1);

            root.Remove(pe);

            // Muestro los nodos recursivamente

            Console.WriteLine("\nDespues de eliminar el nodo primitivo:\n");

            root.Display(1);

            Console.ReadKey();

        }

    }

    // La clase componente

    abstract class DrawingElement

    {

        protected string _name;

        public DrawingElement(string name)

        {

            this._name = name;

        }

        public abstract void Add(DrawingElement d);

        public abstract void Remove(DrawingElement d);

        public abstract void Display(int indent);

    }

    //La clase hoja

    class PrimitiveElement : DrawingElement

    {

        public PrimitiveElement(string name) : base(name){}

        public override void Add(DrawingElement c)

        {

            Console.WriteLine("Cannot add to a PrimitiveElement");

        }

        public override void Remove(DrawingElement c)

        {

            Console.WriteLine("Cannot remove from a PrimitiveElement");

        }

        public override void Display(int indent)

        {

            Console.WriteLine(new String('-', indent) + " " + _name);

        }

    }

    // La clase compuesta

    class CompositeElement : DrawingElement

    {

        private List<DrawingElement> elements = new List<DrawingElement>();

        public CompositeElement(string name): base(name){}

        public override void Add(DrawingElement d)

        {

            elements.Add(d);

        }

        public override void Remove(DrawingElement d)

        {

            elements.Remove(d);

        }

        public override void Display(int indent)

        {

            Console.WriteLine(new String('-', indent) + "+ " + _name);

            // Muestro cada elemento del nodo

            foreach (DrawingElement d in elements)

            {

                d.Display(indent + 2);

            }

        }

    }

}
