// See https://aka.ms/new-console-template for more information

using Arbol.Entities;
using Newtonsoft.Json;


var baseUri = "https://test.defontana.com/";
var httpClient = new HttpClient();
var response = await httpClient.GetAsync(baseUri);
response.EnsureSuccessStatusCode();
var JsonString = await response.Content.ReadAsStringAsync();
var resultado = JsonConvert.DeserializeObject<Organismo>(JsonString);

var lista_ordenada = resultado.data.OrderBy(x => x.Parent).ToList();


CArbol arbol = new CArbol();
CNodo raiz = arbol.Insertar("Organismos ", 0, null);


foreach (var item in lista_ordenada)
{
    CNodo nodo = new CNodo();
    CNodo encontrado = new CNodo();

    encontrado = arbol.Buscar(item.ID, raiz);

    if (encontrado == null)
    {
        nodo = arbol.Insertar(item.Name, item.ID, raiz);

        foreach (var td in lista_ordenada)
        {
            var todos = lista_ordenada.Where(x => x.Parent == item.ID).ToList();

            foreach (var t in todos)
            {
                encontrado = arbol.Buscar(item.ID, raiz);
                arbol.Insertar(t.Name, t.ID, encontrado);
            }
            break;
        }
    }
    else
    {
        foreach (var td in lista_ordenada)
        {
            var todos = lista_ordenada.Where(x => x.Parent == item.ID).ToList();

            foreach (var t in todos)
            {
                encontrado = arbol.Buscar(item.ID, raiz);
                arbol.Insertar(t.Name, t.ID, encontrado);
            }
            break;
        }
    }

}

arbol.Transversa(raiz);
Console.ReadKey();



















