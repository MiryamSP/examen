using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenMiryam
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Type> figuras = new List<Type>()
            {
                typeof(Estrella),
                typeof(Rayo),
                typeof(Corazon),
            };

            var container = new Container(figuras);

            List<Ifigura> figurasUser = new List<Ifigura>();
            var random = new Random(0);
            for (int i = 0; i < 100; i++)
            {
                var index = random.Next(3);
                var type = figuras[index];
                var figura = Activator.CreateInstance(type) as Ifigura;
                figurasUser.Add(figura);
            }

            foreach (var figura in figurasUser)
            {
                Console.WriteLine(figura.ToString());
            }
            Console.ReadLine();

        }
    }
    public enum Colores
    {
        Rojo, Azul, Negro, Amarillo, Verde
    }
    interface Ifigura
    {
        Colores ColorFondo { get; set; }
        Colores ColorBorde { get; set; }
    }
    class Figura : Ifigura
    {
        public Colores ColorFondo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Colores ColorBorde { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    class Estrella : Figura
    {
        public override string ToString()
        {
            return "Soy una estrella";
        }
    }
    class Rayo : Figura
    {
        public override string ToString()
        {
            return "Soy un rayo";
        }
    }
    class Corazon : Figura
    {
        public override string ToString()
        {
            return "Soy un corazón";
        }
    }
    interface IContainer
    {


    }
    /// <summary>
    /// contenedor de figuras
    /// </summary>
    public class Container : IContainer
    {

        readonly IList<Type> _figuras;

        public Container(IList<Type> figuras)
        {
            if (null == figuras)
            {
                throw new ArgumentNullException("figuras");
            }
            _figuras = figuras;
        }
    }

    /// <summary>
    /// contenedor de colores
    /// </summary>
    public class Container1 : IContainer
    {
        readonly IList<Type> _colores;
        public Container1(IList<Type> colores)
        {
            if (null == colores)
            {
                throw new ArgumentNullException("colores");
            }
            _colores = colores;
        }
    }

    /// <summary>
    /// lista de formas y colores, muestra al usuario las listas
    /// </summary>
    interface IToolbar
    {

        IContainer Figuras { get; set; }
        IContainer Colores { get; set; }
    }

    /// <summary>
    /// necesito un metodo que le muestre al usuario las listas de figuras y colores y los elija
    /// </summary>
    public class Toolbar : IToolbar
    {

    }
    interface ILienzo
    {

    }

    /// <summary>
    ///  ejecutar el Tostring por cada lista de figuras, en el lienzo solo hay figuras
    /// </summary>
    public class Lienzo : ILienzo
    {

    }
    public class Paint : ILienzo, IToolbar
    {

    }
}
