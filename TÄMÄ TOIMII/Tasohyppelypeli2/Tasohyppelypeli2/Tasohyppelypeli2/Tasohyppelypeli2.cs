﻿using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class Tasohyppelypeli2 : PhysicsGame
{
   const double nopeus = 400;
    const double hyppyNopeus = 750;
    const int RUUDUN_KOKO = 50;

    PlatformCharacter pelaaja1;
    PhysicsObject yläreuna;
    Image pelaajanKuva = LoadImage("norsu");
    Image tahtiKuva = LoadImage("tahti");
    Image Pahis = LoadImage("Pahis");
    SoundEffect maaliAani = LoadSoundEffect("maali");
   

    public override void Begin()
    {
        Gravity = new Vector(0, -1000);

        LuoKentta();
        LisaaNappaimet();
        LuoAikaLaskuri();
        
        MediaPlayer.Play("Element_of_happiness");
        MediaPlayer.IsRepeating = true;

        Camera.Y = Level.Top - 100;
        Camera.Velocity = new Vector(0, -100);
        Camera.ZoomFactor = 0;
        Camera.StayInLevel = true;
    }

    void LuoKentta()
    {
        TileMap kentta = TileMap.FromLevelAsset("kentta1");
        kentta.SetTileMethod('#', LisaaTaso);
        kentta.SetTileMethod('*', LisaaTahti);
        kentta.SetTileMethod('N', LisaaPelaaja);
        kentta.SetTileMethod('P', lisaaPahis); 
        kentta.Execute(RUUDUN_KOKO, RUUDUN_KOKO);
        
        Level.CreateBorders();
        yläreuna = Level.CreateTopBorder();
        Add(yläreuna);
        Level.Background.CreateGradient(Color.Red, Color.Black);

    }
   


    void LisaaTaso(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject taso = PhysicsObject.CreateStaticObject(leveys, korkeus);
        taso.Position = paikka;
        taso.Color = Color.Black;
        Add(taso);
    }
    void lisaaPahis(Vector paikka, double leveus, double korkeus)
    {
        PhysicsObject Pahis = PhysicsObject.CreateStaticObject(2000, korkeus);
        Pahis.IgnoresCollisionResponse = false;
         Pahis.Position = paikka;
         Pahis.Y = Level.Top - 0;
         Pahis.Velocity = new Vector(0, -100);
         Camera.StayInLevel = true;
         Pahis.Color = (Color.Black);
        Pahis.Tag = "pahis";
        Add(Pahis);
        
    }
    void LisaaTahti(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject tahti = PhysicsObject.CreateStaticObject(leveys, korkeus);
        tahti.IgnoresCollisionResponse = true;
        tahti.Position = paikka;
        tahti.Image = tahtiKuva;
        tahti.Tag = "tahti";
        Add(tahti);
    }
    void LuoVihollinen(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject vihollinen = new PhysicsObject(leveys, korkeus);
        vihollinen.Position = paikka;
        
        vihollinen.Tag = "pahis";
        AddCollisionHandler(pelaaja1, "Pahis", tormaaPahikseen);
        Add(vihollinen);
    }
    void LisaaPelaaja(Vector paikka, double leveys, double korkeus)
    {
        pelaaja1 = new PlatformCharacter(leveys, korkeus);
        pelaaja1.Position = paikka;
        pelaaja1.Mass = 5.0;
        pelaaja1.Image = pelaajanKuva;
        AddCollisionHandler(pelaaja1, "Pahis", tormaaPahikseen);

        AddCollisionHandler(pelaaja1, "tahti", TormaaTahteen);
        Add(pelaaja1);
    }


    void LisaaNappaimet()
    {
        Keyboard.Listen(Key.F1, ButtonState.Pressed, ShowControlHelp, "Näytä ohjeet");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");

        Keyboard.Listen(Key.Left, ButtonState.Down, Liikuta, "Liikkuu vasemmalle", pelaaja1, -nopeus);
        Keyboard.Listen(Key.Right, ButtonState.Down, Liikuta, "Liikkuu vasemmalle", pelaaja1, nopeus);
        Keyboard.Listen(Key.Up, ButtonState.Pressed, Hyppaa, "Pelaaja hyppää", pelaaja1, hyppyNopeus);
       
        ControllerOne.Listen(Button.Back, ButtonState.Pressed, Exit, "Poistu pelistä");

        ControllerOne.Listen(Button.DPadLeft, ButtonState.Down, Liikuta, "Pelaaja liikkuu vasemmalle", pelaaja1, -nopeus);
        ControllerOne.Listen(Button.DPadRight, ButtonState.Down, Liikuta, "Pelaaja liikkuu oikealle", pelaaja1, nopeus);
        ControllerOne.Listen(Button.A, ButtonState.Pressed, Hyppaa, "Pelaaja hyppää", pelaaja1, hyppyNopeus);

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
    }

    void Liikuta(PlatformCharacter hahmo, double nopeus)
    {
        Angle kulma = hahmo.Angle;
        kulma.Degrees += 10000;
        hahmo.Angle = kulma;
        hahmo.Walk(nopeus);
    }

    void Hyppaa(PlatformCharacter hahmo, double nopeus)
    {
        hahmo.Jump(nopeus);
    }

    void tormaaPahikseen(PhysicsObject hahmo, PhysicsObject Pahis)
         {
             if (pelaaja1 == Pahis)
             {
                 pelaaja1.Destroy();
             }
        MessageDisplay.Add("Kuolit!!");
        pelaaja1.Destroy();
         }
    void TormaaTahteen(PhysicsObject hahmo, PhysicsObject tahti)
    {
        if (tahti == yläreuna)
        {
            hahmo.Destroy();
        }
        maaliAani.Play();
        MessageDisplay.Add("Keräsit tähden!");
        tahti.Destroy();
    }
    void LuoAikaLaskuri()
    {
        Timer aikaLaskuri = new Timer();
        aikaLaskuri.Start();

        Label aikaNaytto = new Label();
        aikaNaytto.TextColor = Color.White;
        aikaNaytto.DecimalPlaces = 1;
        aikaNaytto.BindTo(aikaLaskuri.SecondCounter);
        Add(aikaNaytto);
    }
    
        

   
}