using MultiShop.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ContactService
{
    public class ContactService:IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateContactAsync(CreateContactDto ContactDto)
        {
            await _httpClient.PostAsJsonAsync<CreateContactDto>("contacts", ContactDto);

        }

        public async Task DeleteContactAsync(string id)
        {
            await _httpClient.DeleteAsync("contacts?id=" + id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var responseMessage = await _httpClient.GetAsync("contacts");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultContactDto>>();
            return values;
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("contacts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdContactDto>();
            return values;
        }

        public async Task UpdateContactAsync(UpdateContactDto ContactDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateContactDto>("contacts", ContactDto);
        }
    }
}
