namespace Arbol.Entities
{
    public class CArbol
    {
        public CNodo raiz { get; set; }
        public CNodo trabajo { get; set; }

        public int i = 0;

        public CArbol()
        {
            raiz = new CNodo();
        }

        public CNodo Insertar(string pdato, int pvalor, CNodo pNodo)
        {
            if (pNodo == null)
            {
                raiz = new CNodo();
                raiz.dato = pdato;
                raiz.valor = pvalor;


                raiz.hijo = null;

                raiz.hermano = null;

                return raiz;
            }

            if (pNodo.hijo == null)
            {
                CNodo temp = new CNodo();
                temp.dato = pdato;
                temp.valor = pvalor;


                //Conectamos con el nuevo nodo hijo
                pNodo.hijo = temp;
                return temp;
            }
            else //ya tiene hijo, hay que insertarlo como hermano
            {
                trabajo = pNodo.hijo;

                //Avanzamos hasta el ultimo hermani
                while (trabajo.hermano != null)
                {
                    trabajo = trabajo.hermano;
                }

                //Creamos nodo temporal
                CNodo temp = new CNodo();
                temp.dato = pdato;
                temp.valor = pvalor;

                //unimos el temp al ultimo hermano
                trabajo.hermano = temp;

                return temp;
            }
        }

        public void Transversa(CNodo cNodo)
        {
            if (cNodo == null)
                return;

            for (int n = 0; n < i; n++)

                Console.Write("--");

            Console.WriteLine(cNodo.dato);

            if (cNodo.hijo != null)
            {
                i++;
                Transversa(cNodo.hijo);
                i--;
            }

            if (cNodo.hermano != null)
            {
                Transversa(cNodo.hermano);
            }



        }

        public CNodo Buscar(int pvalor, CNodo pNodo)
        {
            CNodo encontrado = null;
            if (pNodo == null)
                return encontrado;


            if (pNodo.valor == pvalor)
            {
                encontrado = pNodo;
                return encontrado;
            }

            //al hijo

            if (pNodo.hijo != null)
            {
                encontrado = Buscar(pvalor, pNodo.hijo);

                if (encontrado != null)
                    return encontrado;

            }

            //al hermano

            if (pNodo.hermano != null)
            {
                encontrado = Buscar(pvalor, pNodo.hermano);

                if (encontrado != null)
                    return encontrado;

            }

            return encontrado;

        }
    }
}
