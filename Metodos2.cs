using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Proyecto_Inf_281
{
    class Metodos2
    {

      
        public static byte[] Imagen_Bytes(string Ruta_Cargada) 
        {
       
        byte[] Obtener_Arrays_Bytes = null;
        if( String.IsNullOrEmpty(Ruta_Cargada) == true )
        {
            MessageBox.Show("imagen no puede ser nulo o vacío", "Info DansZavach");
            return null;
        }
        try{
            System.IO.FileInfo Copia_Contenido = new  System.IO.FileInfo(Ruta_Cargada);
            long Obtener_Longitud = Copia_Contenido.Length;
            System.IO.FileStream Leer_Archivo = new  System.IO.FileStream(Ruta_Cargada,  System.IO.FileMode.Open,  System.IO.FileAccess.Read);
            System.IO.BinaryReader Obtener_Codificacion_Binaria = new  System.IO.BinaryReader(Leer_Archivo);
            Obtener_Arrays_Bytes = Obtener_Codificacion_Binaria.ReadBytes(Convert.ToInt32(Obtener_Longitud));
            Copia_Contenido = null;
            Obtener_Longitud = 0;
            Leer_Archivo.Close();
            Leer_Archivo.Dispose();
            Obtener_Codificacion_Binaria.Close();

            return Obtener_Arrays_Bytes;
        }catch(Exception ex){
            return null;
        }
    }  
    public static byte[] Objeto_Image_A_Bytes(System.Drawing.Image Recupero_Image, System.Drawing.Imaging.ImageFormat Obtener_Formato) 
    {
         System.IO.MemoryStream Crea_Secuencia = new  System.IO.MemoryStream();
        try{
            if( Recupero_Image != null ){
                Recupero_Image.Save(Crea_Secuencia, Obtener_Formato);
                return Crea_Secuencia.ToArray(); // lo vuelvo array o matris
            }else{
                return null;
            }
        }catch(Exception ex){
            return null;
        }
        return Crea_Secuencia.ToArray();
    }  
    public static Image Bytes_A_Imagen(byte[] Imagen)
    {
        try{
            if( Imagen != null )
            {
                 System.IO.MemoryStream Secuencia = new  System.IO.MemoryStream(Imagen); //capturar array con memorystream hacia Bin
                Image Resultado = Image.FromStream(Secuencia); //con el método FroStream de Image obtenemos imagen
                return Resultado; //y la retornamos
            }
            else
            {
                return null;
            }
        }
        catch(Exception ex)
        {return null;}
    }  

    
   
 
   
    
  





    }
}
