import axios from "axios";

export default {
  api(controller) {
    const localUrl = "http://localhost:62573/api";
    return {
      getAll: () => axios.get(`${localUrl}/${controller}`),
      delete: id => axios.delete(`${localUrl}/${controller}/${id}`),
      post: data =>
        axios
          .post(`${localUrl}/${controller}`, data)
          .then(function(response) {
            window.alert("Pomyślnie dodano obiekt do bazy");
          })
          .catch(function(error) {
            window.alert("Błąd serwera! Taki obiekt już istnieje w bazie!");
          }),
      getOne: id => axios.get(`${localUrl}/${controller}/${id}`)
    };
  }
};
