using Avalonia.Headless.XUnit;
using Xunit;
using RapidPack;

namespace RapidPack.Tests;

public class MainWindowTests
{
    [AvaloniaFact]
    public void UtworzOkno_PowinnoZainicjalizowacMainWindow()
    {
        var window = new MainWindow();
        Assert.NotNull(window);
    }

    [Fact]
    public void Test_WagaPowyzej30_Blad()
    {
        var logic = new ParcelLogic();
        Assert.Equal(-1, logic.Calculate(31, 10, 10, 10, false, 0));
    }

    [Fact]
    public void Test_Paleta_CenaStala()
    {
        var logic = new ParcelLogic();
        Assert.Equal(100.0, logic.Calculate(10, 200, 200, 200, false, 2));
    }

    [Fact]
    public void Test_Gabaryt_Dolicza50Procent()
    {
        var logic = new ParcelLogic();
        Assert.Equal(15.0, logic.Calculate(0, 60, 60, 60, false, 0));
    }

    [Fact]
    public void Test_Paczka50x50x60_DoliczaGabaryt()
    {
        var logic = new ParcelLogic();
        Assert.Equal(15.0, logic.Calculate(0, 50, 50, 60, false, 0));
    }

    [Fact]
    public void Test_PaletaZEkspresem_Dolicza15Zl()
    {
        var logic = new ParcelLogic();
        Assert.Equal(115.0, logic.Calculate(10, 10, 10, 10, true, 2));
    }

    [Fact]
    public void Test_PaczkaOstroznie_Dolicza10Zl()
    {
        var logic = new ParcelLogic();
        Assert.Equal(20.0, logic.Calculate(0, 10, 10, 10, false, 1));
    }

    [Fact]
    public void Test_PelnaWycena_WszystkieDodatki()
    {
        var logic = new ParcelLogic();
        Assert.Equal(60.0, logic.Calculate(5, 60, 60, 60, true, 1));
    }
}