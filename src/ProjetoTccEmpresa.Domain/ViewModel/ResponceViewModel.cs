namespace ProjetoTccEmpresa.Domain.ViewModel
{
    public class ResponceViewModel<T>
    {
        public ResponceViewModel()
        {
            Notifications = new List<NotificationViewModel>();
        }

        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<NotificationViewModel> Notifications { get; set; }
        public T Data { get; set; }
    }
}
