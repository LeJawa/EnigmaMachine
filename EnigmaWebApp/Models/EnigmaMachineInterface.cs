using Blazor.Extensions.Canvas.Canvas2D;
using Enigma;

namespace EnigmaWebApp.Models;

public class EnigmaMachineInterface
{
    private EnigmaMachine _enigma;
    public EnigmaMachine.Info EnigmaInfo => _enigma.GetInfo();
    
    public double Width { get; private set; }
    public double Height { get; private set; }

    public void Resize(double width, double height) =>
        (Width, Height) = (width-310, height-200);

    public EnigmaMachineInterface()
    {
        _enigma = new EnigmaMachine(
            "B", 
            "II IV V", 
            "B L A", 
            "02 21 12", 
            "AV BS CG DL FU HZ IN KM OW RX"
        );
    }

    public async ValueTask Draw(Canvas2DContext context)
    {
        await context.SetFillStyleAsync("green");

        await context.FillRectAsync(0, 0, Width, Height);
        await context.SetFillStyleAsync("white");

        int paddingX = 10;
        int paddingY = 10;
        int x = paddingX;
        int y = paddingY;

        int columns = 6;
        int rows = 26;

        float letterFillPercentage = 0.8f;

        int numberOfRotors = 3;
        int numberOfComponents = numberOfRotors + 2;
        
        int columnWidth = ((int)Width - paddingX*(numberOfComponents+1)) / numberOfComponents;

        int cellWidth = (columnWidth - paddingX*(columns+1)) / columns;
        int cellHeight = ((int)Height - paddingY*(rows+1)) / rows;

        for (int i = 0; i < numberOfComponents; i++)
        {
            foreach (char letter in "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
            {
                await context.FillRectAsync(x, y, cellWidth, cellHeight);
                await context.FillRectAsync(x + columnWidth - paddingX - cellWidth, y, cellWidth, cellHeight);
                
                await context.SetFontAsync($"{(int)cellHeight*letterFillPercentage}px serif");
                await context.StrokeTextAsync(letter.ToString()+i.ToString(), x + cellWidth/2, y + cellHeight*letterFillPercentage);
                await context.StrokeTextAsync(letter.ToString()+i.ToString(), x + columnWidth - paddingX - cellWidth/2, y + cellHeight*letterFillPercentage);

                y += cellHeight + paddingY;
            
                if(y + cellHeight > Height)
                    break;
            }
            y = paddingY;
            x += columnWidth + paddingX;
        }
    }
    
}