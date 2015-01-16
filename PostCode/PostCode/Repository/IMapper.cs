namespace PostCode.Repository
{
    public interface IMapper<Def, My>
        where Def : class
        where My : class
    {
        My MappingToDefU(Def entity);
        Def MappingFromDefU(My entity);
    }
}
