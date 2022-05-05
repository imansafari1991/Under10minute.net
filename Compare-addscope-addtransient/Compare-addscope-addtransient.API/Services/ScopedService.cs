namespace Compare_addscope_addtransient.API.Services
{
    public class ScopedService:IScopedService
    {


        public ScopedService()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
