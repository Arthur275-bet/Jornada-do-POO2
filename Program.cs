using System;


public abstract class VeiculoTerrestre
{
    public string Nome { get; protected set; }

    protected VeiculoTerrestre(string nome)
    {
        Nome = nome;
    }


    public abstract void Mover();
}


public class CarroJoao : VeiculoTerrestre
{

    private int _potenciaMotor;
    private bool _motorLigado;

    public CarroJoao(string nome = "CarroJoão", int potenciaMotor = 100)
        : base(nome)
    {
        _potenciaMotor = potenciaMotor;
    }

    public void Ligar()
    {
        IniciarSistemaEletrico();
        InjetarCombustivel();
        _motorLigado = true;
        Console.WriteLine($"{Nome} ligado!");
    }


    private void IniciarSistemaEletrico() { /* ... */ }
    private void InjetarCombustivel() { /* ... */ }


    public override void Mover()
    {
        if (!_motorLigado)
        {
            Console.WriteLine($"{Nome} precisa ser ligado primeiro.");
            return;
        }
        Console.WriteLine($"{Nome} avança sobre quatro rodas com {_potenciaMotor} cv.");
    }
}


public class CarroJoaoSports : CarroJoao
{
    public CarroJoaoSports() : base("CarroJoãoSports", 300) { }

    public override void Mover()
    {
        base.Mover();
        Console.WriteLine("...com aceleração esportiva!");
    }
}

public class CarroJoaoSUV : CarroJoao
{
    public int CapacidadeCargaKg { get; } = 800;

    public CarroJoaoSUV() : base("CarroJoãoSUV", 180) { }
}

public class CarroJoaoEco : CarroJoao
{
    public CarroJoaoEco() : base("CarroJoãoEco", 120) { }

    public override void Mover()
    {
        base.Mover();
        Console.WriteLine("...com propulsão elétrica, em silêncio.");
    }
}


public class OnibusJoao : VeiculoTerrestre
{
    public OnibusJoao() : base("ÔnibusJoão") { }
    public override void Mover() =>
        Console.WriteLine($"{Nome} avança seguindo a rota e parando nos pontos.");
}

public class CaminhaoJoao : VeiculoTerrestre
{
    public CaminhaoJoao() : base("CaminhãoJoão") { }
    public override void Mover() =>
        Console.WriteLine($"{Nome} avança lentamente transportando carga pesada.");
}

public class MotoJoao : VeiculoTerrestre
{
    public MotoJoao() : base("MotoJoão") { }
    public override void Mover() =>
        Console.WriteLine($"{Nome} avança ágil sobre duas rodas.");
}

public class Program
{
    public static void Main()
    {
        var carro = new CarroJoao();
        carro.Ligar();

        var sports = new CarroJoaoSports();
        sports.Ligar();

        var eco = new CarroJoaoEco();
        eco.Ligar();


        VeiculoTerrestre[] frota =
        {
            carro,
            sports,
            eco,
            new OnibusJoao(),
            new CaminhaoJoao(),
            new MotoJoao()
        };

        Console.WriteLine("\n--- Desfile de lançamento ---");
        foreach (VeiculoTerrestre veiculo in frota)
        {
            veiculo.Mover();
        }
    }
}