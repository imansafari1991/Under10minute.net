namespace Compare_addscope_addtransient.API.Services
{
    public class TransientService : ITransientService
    {

        public TransientService()
        {
            Id=Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
