using School.BL;
using School.BL.Models.DetailModels;
using School.BL.Models.ListModels;
using School.DAL.Entities;

namespace School.App.ViewModels
{
    public class AddressViewModel
    {
        private readonly CrudFacade<AddressEntity, AddressListModel, AddressDetailModel> addressFacade;
        private readonly Messenger messenger;

        public AddressViewModel(Messenger messenger,
            CrudFacade<AddressEntity, AddressListModel, AddressDetailModel> addressFacade)
        {
            this.messenger = messenger;
            this.addressFacade = addressFacade;
        }
    }
}