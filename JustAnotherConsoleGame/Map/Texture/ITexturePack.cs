namespace JustAnotherConsoleGame.Map.Texture
{
    public interface ITexturePack
    {
        char Player { get; }

        char this[CellType? index] { get; }
    }
}
