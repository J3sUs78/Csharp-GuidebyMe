class Lenguaje
{
    private string nombre;
    private int year;

    public Lenguaje(string nombre, int year)
    {
        this.nombre = nombre;
        this.year = year;
    }

    public void descripcion()
    {
        Console.WriteLine("{0} fue creado en {1}",this.nombre,this.year);
    }

}