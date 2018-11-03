namespace JustAnotherConsoleGame.Map.Texture
{
    public interface ITexturePack
    {
        char this[CellType? index] { get; }
    }
}
