using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;
using System.Runtime.CompilerServices;


class Harjoitukset : Tarkistaja
{
    
    public override int Tehtava1(int a, int b)
    {
        

        return (a+b);
        // TODO: Ota tehtävä pois kommenteista ja kirjoita toteutus tähän
        
    }
  


    
    public override double Tehtava2(double x, double y, double z)
    {
        
       return (z+y+x)/3;
        // Vinkki: http://bit.ly/OieLwT
        

        // TODO: Ota tehtävä pois kommenteista ja kirjoita toteutus tähän
      
    }
   


    
    public override void Tehtava3()
    {
        
        PhysicsObject pallo = new PhysicsObject(40.0, 40.0);
        pallo.Shape = Shape.Circle;
        pallo.Color = Color.Red;

        Add(pallo);
        // TODO: Ota tehtävä pois kommenteista ja kirjoita toteutus tähän
    }
 


    
    public override void Tehtava4(int n)
    {
       
       for (int i = 0; i < n; i++)
    {
        PhysicsObject pallo = new PhysicsObject(40.0, 40.0);
        pallo.Shape = Shape.Circle;
        pallo.Color = Color.White;
        pallo.Position = RandomGen.NextVector(0.0, 300.0);
        Add(pallo);
        
        }
        // TODO: Ota tehtävä pois kommenteista ja kirjoita toteutus tähän
    }
  


   
    public override void Tehtava5()
    {
        // Tehtävänanto: Lisää peliin reunat joka puolelle
        Level.CreateBorders(1.0, false);
        // TODO: Ota tehtävä pois kommenteista ja kirjoita toteutus tähän
    }
    


   
    public override void Tehtava6()
    {
        // Tehtävänanto: Lyö PUNAISELLE pallolle vauhtia satunnaiseen suuntaan
       
        // Vinkki, tee Tehtava3-aliohjelmassa lisättävästä pallosta luokkamuuttuja.

        // TODO: Ota tehtävä pois kommenteista ja kirjoita toteutus tähän
    }
    
    

    /* POISTA TÄMÄ RIVI...
    public override void Tehtava7(List<PhysicsObject> pallot)
    {
        // Tehtävänanto: Kun kaksi VALKOISTA palloa osuu toisiinsa, pistä ne katoamaan
        //  lisäpisteitä jos saat ne räjähtämään (kersku siitä kaverille ja opettajille :)
        //
        // Vinkki: käy pallot-lista läpi for-silmukassa ja lisää törmäyskäsittelijä,
        //  ja sille uusi aliohjelma.

        // TODO: Ota tehtävä pois kommenteista ja kirjoita toteutus tähän
    }
    ...JA POISTA TÄMÄ RIVI */


    /* POISTA TÄMÄ RIVI...
    public override void Tehtava8()
    {
        // Tehtävänanto: Aina kun välilyöntiä painetaan, lyö PUNAISELLE pallolle lisää vauhtia.
        // 
        // Vinkki: uudelleenkäytä Tehtava6-aliohjelmaa tapahtumakäsittelijässä.

        // TODO: Ota tehtävä pois kommenteista ja kirjoita toteutus tähän
    }
    ...JA POISTA TÄMÄ RIVI */


    /* POISTA TÄMÄ RIVI...
    public override void Tehtava9(int pallojaTallaHetkella)
    {
        // Tehtävänanto: Lisää ruudulla näkyvä laskuri, joka pitää kirjaa siitä montako VALKOISTA
        //  palloa on vielä pelissä.
        //
        // Vinkki: Tee laskurille luokkamuuttuja, jonka arvo on aluksi null (eli ei arvoa).
        //  Tässä aliohjelmassa luo sitten se laskuri ja näyttö. Uudelleenkäytä Tehtävän 7
        //  törmäyskäsittelijää, jossa muuta laskurin arvoa VAIN JOS SE EI OLE null.

        // TODO: Ota tehtävä pois kommenteista ja kirjoita toteutus tähän
    }
    ...JA POISTA TÄMÄ RIVI */


    /* POISTA TÄMÄ RIVI...
    public override void Tehtava10()
    {
        // Tehtävänanto: Kun jäljellä on enää alle puolet VALKOISISTA palloista, vaihda kentän 
        //  taustaväri vaaleanpunaiseksi (Color.Pink).
        //
        // Vinkki: Kutsu tätä aliohjelmaa tehtävän 7 törmäyskäsittelijässä. Kannattaa myös käyttää 
        //  apuna tehtävän 9 laskuria.

        // TODO: Ota tehtävä pois kommenteista ja kirjoita toteutus tähän
    }
    ...JA POISTA TÄMÄ RIVI */
}
