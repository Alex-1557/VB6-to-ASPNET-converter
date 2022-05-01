Imports System
Imports System.Text
Imports System.Xml

Module Program
    Sub Main(args As String())
        Dim doc As New XmlDocument()
        Dim doc1 As New XmlDocument()
        doc.LoadXml(Xml.ToString)
        doc1.LoadXml(Xml1.ToString)
        Dim NodeList As XmlNodeList = doc.SelectNodes("/root/div")
        Dim NodeList1 As XmlNodeList = doc1.SelectNodes("/root/div")
        Dim OrderdList = NodeList.Cast(Of XmlNode).OrderBy(Function(X) CInt(X.Attributes("Left").InnerText)).ThenBy(Function(X) CInt(X.Attributes("Top").InnerText)).ToList
        Dim Out1 As New StringBuilder
        OrderdList.ForEach(Sub(X)
                               Out1.AppendLine("<div>")
                               Dim SelectedLabel = NodeList1.Cast(Of XmlNode).Where(Function(y) y.Attributes("Tag").InnerText.Replace("""", "") = X.Attributes("title").InnerText).FirstOrDefault
                               Out1.AppendLine($"<label>{SelectedLabel.Attributes("title").InnerText}</label>")
                               Out1.AppendLine($"@Html.TextBoxFor(x=>x.{X.Attributes("title").InnerText}, new {{ title=""{SelectedLabel.Attributes("title").InnerText}""}})")
                               Out1.AppendLine("</div>")
                           End Sub)
        IO.File.WriteAllText("J:\Ftp\form.htm", Out1.ToString)
        Console.ReadLine()
    End Sub

    Dim Xml = <root>
                  <div type='TextBox' name='txtStatistika00' id='txtStatistika00' title="_01_Stevilo_intervencij_zdravnik" Top='600' Left='3600'/>
                  <div type='TextBox' name='txtStatistika01' id='txtStatistika01' title="_09_Stevilo_pacientov_prepeljanih_v_SUC" Top='5640' Left='3600'/>
                  <div type='TextBox' name='txtStatistika02' id='txtStatistika02' title="_01_Stevilo_intervencij_brez_zdravnika" Top='960' Left='3600'/>
                  <div type='TextBox' name='txtStatistika03' id='txtStatistika03' title="_29_Prijavitelj_je_112" Top='600' Left='13320'/>
                  <div type='TextBox' name='txtStatistika04' id='txtStatistika04' title="_29_Prijavitelj_je_PacientSam" Top='960' Left='13320'/>
                  <div type='TextBox' name='txtStatistika05' id='txtStatistika05' title="_41_Stevilo_prestopov_zdravnika_v_NRV" Top='1440' Left='3240'/>
                  <div type='TextBox' name='txtStatistika06' id='txtStatistika06' title="_37_Stevilo_obrazcev_mat" Top='360' Left='3240'/>
                  <div type='TextBox' name='txtStatistika07' id='txtStatistika07' title="_39_Stevilo_HAT_positivnih" Top='720' Left='3240'/>
                  <div type='TextBox' name='txtStatistika08' id='txtStatistika08' title="_40_Stevilo_HAT_negativnih" Top='1080' Left='3240'/>
                  <div type='TextBox' name='txtStatistika09' id='txtStatistika09' title="_04_Povprecni_Klic_VrnitevVIzhodice_v_sekundah" Top='2520' Left='3600'/>
                  <div type='TextBox' name='txtStatistika10' id='txtStatistika10' title="_06_Skupno_stevilo_opr_km" Top='3600' Left='3600'/>
                  <div type='TextBox' name='txtStatistika11' id='txtStatistika11' title="_38_Stevilo_obrazcev_o" Top='4200' Left='13320'/>
                  <div type='TextBox' name='txtStatistika12' id='txtStatistika12' title="_35_Stevilo_obrazcev_ppo" Top='3480' Left='13320'/>
                  <div type='TextBox' name='txtStatistika13' id='txtStatistika13' title="_33_Stevilo_obrazcev_sni" Top='2760' Left='13320'/>
                  <div type='TextBox' name='txtStatistika14' id='txtStatistika14' title="_36_Stevilo_obrazcev_prp" Top='3840' Left='13320'/>
                  <div type='TextBox' name='txtStatistika15' id='txtStatistika15' title="_34_Stevilo_obrazcev_pni" Top='3120' Left='13320'/>
                  <div type='TextBox' name='txtStatistika16' id='txtStatistika16' title="_29_Prijavitelj_je_Drugo" Top='1320' Left='13320'/>
                  <div type='TextBox' name='txtStatistika17' id='txtStatistika17' title="_29_Prijavitelj_je_ZdravstveniDisp" Top='240' Left='13320'/>
                  <div type='TextBox' name='txtStatistika18' id='txtStatistika18' title="_29_Prijavitelj_je_Zdravnik" Top='7560' Left='8640'/>
                  <div type='TextBox' name='txtStatistika19' id='txtStatistika19' title="_29_Prijavitelj_je_Policija" Top='7200' Left='8640'/>
                  <div type='TextBox' name='txtStatistika20' id='txtStatistika20' title="_29_Prijavitelj_je_Ocividci" Top='6840' Left='8640'/>
                  <div type='TextBox' name='txtStatistika21' id='txtStatistika21' title="_19_St_Endotrahealnih_intubacij" Top='2640' Left='8640'/>
                  <div type='TextBox' name='txtStatistika22' id='txtStatistika22' title="_32_Vpliv_mamil" Top='2400' Left='13320'/>
                  <div type='TextBox' name='txtStatistika23' id='txtStatistika23' title="_31_Vpliv_alkohola" Top='2040' Left='13320'/>
                  <div type='TextBox' name='txtStatistika24' id='txtStatistika24' title="_30_St_int_z_vec_pac" Top='1680' Left='13320'/>
                  <div type='TextBox' name='txtStatistika25' id='txtStatistika25' title="_29_Prijavitelj_je_Svojec" Top='6480' Left='8640'/>
                  <div type='TextBox' name='txtStatistika26' id='txtStatistika26' title="_28_St_mrtvih_ob_prihodu" Top='6120' Left='8640'/>
                  <div type='TextBox' name='txtStatistika27' id='txtStatistika27' title="_27_St_elektro_konverzija" Top='5760' Left='8640'/>
                  <div type='TextBox' name='txtStatistika28' id='txtStatistika28' title="_26_St_zun_elektorstim" Top='5280' Left='8640'/>
                  <div type='TextBox' name='txtStatistika29' id='txtStatistika29' title="_25_St_defibrilacij_Prvi_posredovalci" Top='4800' Left='8640'/>
                  <div type='TextBox' name='txtStatistika30' id='txtStatistika30' title="_24_St_defibrilacij" Top='4440' Left='8640'/>
                  <div type='TextBox' name='txtStatistika31' id='txtStatistika31' title="_23_St_12_kanalnih_EKG" Top='4080' Left='8640'/>
                  <div type='TextBox' name='txtStatistika32' id='txtStatistika32' title="_22_St_Intraosalnih_Poti" Top='3720' Left='8640'/>
                  <div type='TextBox' name='txtStatistika33' id='txtStatistika33' title="_21_St_Venskih_poti" Top='3360' Left='8640'/>
                  <div type='TextBox' name='txtStatistika34' id='txtStatistika34' title="_20_Stevilo_uporabljenih_supragloticnih_pripomockov" Top='3000' Left='8640'/>
                  <div type='TextBox' name='txtStatistika35' id='txtStatistika35' title="_18_St_Ozivljanje_Odpust_cpc34" Top='2280' Left='8640'/>
                  <div type='TextBox' name='txtStatistika36' id='txtStatistika36' title="_18_St_Ozivljanje_Odpust_cpc12" Top='1800' Left='8640'/>
                  <div type='TextBox' name='txtStatistika37' id='txtStatistika37' title="_17_St_Ozivl_s_Cirkul_Priv_posred" Top='1320' Left='8640'/>
                  <div type='TextBox' name='txtStatistika38' id='txtStatistika38' title="_16_St_ozivljanj_z_vzpostavitvijo_cirk" Top='840' Left='8640'/>
                  <div type='TextBox' name='txtStatistika39' id='txtStatistika39' title="_15_Stevilo_ozivljanj_prvi_posred" Top='360' Left='8640'/>
                  <div type='TextBox' name='txtStatistika40' id='txtStatistika40' title="_14_Stevilo_Ozivljanj" Top='7440' Left='3600'/>
                  <div type='TextBox' name='txtStatistika41' id='txtStatistika41' title="_13_Stevilo_nepotrebnih_intervencij" Top='6960' Left='3600'/>
                  <div type='TextBox' name='txtStatistika42' id='txtStatistika42' title="_12_Stevilo_pac_ostali_na_kraju" Top='6600' Left='3600'/>
                  <div type='TextBox' name='txtStatistika43' id='txtStatistika43' title="_11_Stevilo_pac_v_druge_zavode" Top='6120' Left='3600'/>
                  <div type='TextBox' name='txtStatistika44' id='txtStatistika44' title="_10_Stevilo_pacientov_prepeljanih_v_ANMP" Top='5160' Left='3600'/>
                  <div type='TextBox' name='txtStatistika45' id='txtStatistika45' title="_09_Stevilo_pacientov_prepeljanih_v_UC" Top='4680' Left='3600'/>
                  <div type='TextBox' name='txtStatistika46' id='txtStatistika46' title="_08_Stevilo_Pacientov_v_prometnih" Top='4320' Left='3600'/>
                  <div type='TextBox' name='txtStatistika47' id='txtStatistika47' title="_07_Stevilo_Pacientov" Top='3960' Left='3600'/>
                  <div type='TextBox' name='txtStatistika48' id='txtStatistika48' title="_06_Povprecno_stevilo_opr_km" Top='3240' Left='3600'/>
                  <div type='TextBox' name='txtStatistika49' id='txtStatistika49' title="_05_Klic_VrnitevVIzhodice_v_sekundah" Top='2880' Left='3600'/>
                  <div type='TextBox' name='txtStatistika50' id='txtStatistika50' title="_03_Povprecni_odzivni_cas_PP" Top='2160' Left='3600'/>
                  <div type='TextBox' name='txtStatistika51' id='txtStatistika51' title="_03_Povprecni_odzivni_cas_v_sekundah" Top='1680' Left='3600'/>
                  <div type='TextBox' name='txtStatistika52' id='txtStatistika52' title="_02_Stevilo_aktivacij_prvih_posredovalcev" Top='1320' Left='3600'/>
                  <div type='TextBox' name='txtStatistika53' id='txtStatistika53' title="_01_Stevilo_intervencij" Top='240' Left='3600'/>
              </root>

    Dim Xml1 = <root>
                   <div type='Label' name='lbl00' id='lbl00' title="Število  prestopov zdravnika iz VUZ v NRV:" Tag='"_41_Stevilo_prestopov_zdravnika_v_NRV"' Top='1440' Left='65'/>
                   <div type='Label' name='lbl01' id='lbl01' title="Število  obrazcev MAT:" Tag='"_37_Stevilo_obrazcev_mat"' Top='360' Left='1320'/>
                   <div type='Label' name='lbl02' id='lbl02' title="Število  pozitivnih HAT testov:" Tag='"_39_Stevilo_HAT_positivnih"' Top='720' Left='840'/>
                   <div type='Label' name='lbl03' id='lbl03' title="Število  negativnih HAT testov:" Tag='"_40_Stevilo_HAT_negativnih"' Top='1080' Left='840'/>
                   <div type='Label' name='lbl04' id='lbl04' title="Število  pacientov pripeljanih v SUC:" Tag='"_09_Stevilo_pacientov_prepeljanih_v_SUC"' Top='5640' Left='120'/>
                   <div type='Label' name='lbl05' id='lbl05' title="Število  intervencij brez zdravnika:" Tag='"_01_Stevilo_intervencij_brez_zdravnika"' Top='960' Left='120'/>
                   <div type='Label' name='lbl06' id='lbl06' title="Število  intervencij z zdravnikom:" Tag='"_01_Stevilo_intervencij_zdravnik"' Top='600' Left='120'/>
                   <div type='Label' name='lbl07' id='lbl07' title="Število  obrazcev O:" Tag='"_38_Stevilo_obrazcev_o"' Top='4200' Left='11400'/>
                   <div type='Label' name='lbl08' id='lbl08' title="Povpreèni  èas klic izhodišèe [ure:min:sek]:" Tag='"_04_Povprecni_Klic_VrnitevVIzhodice_v_sekundah"' Top='2520' Left='120'/>
                   <div type='Label' name='lbl09' id='lbl09' title="Skupno  število opravljenih km na intervenciji:" Tag='"_06_Skupno_stevilo_opr_km"' Top='3600' Left='120'/>
                   <div type='Label' name='lbl10' id='lbl10' title="Število  obrazcev PRP:" Tag='"_36_Stevilo_obrazcev_prp"' Top='3840' Left='11400'/>
                   <div type='Label' name='lbl11' id='lbl11' title="Število  obrazcev PPO:" Tag='"_35_Stevilo_obrazcev_ppo"' Top='3480' Left='11400'/>
                   <div type='Label' name='lbl12' id='lbl12' title="Število  intervencij:" Tag='"_01_Stevilo_intervencij"' Top='240' Left='120'/>
                   <div type='Label' name='lbl13' id='lbl13' title="Število  obrazcev PNI:" Tag='"_34_Stevilo_obrazcev_pni"' Top='3120' Left='11040'/>
                   <div type='Label' name='lbl14' id='lbl14' title="Število  obrazcev SNI:" Tag='"_33_Stevilo_obrazcev_sni"' Top='2760' Left='11040'/>
                   <div type='Label' name='lbl15' id='lbl15' title="Vpliv  mamil:" Tag='"_32_Vpliv_mamil"' Top='2400' Left='12360'/>
                   <div type='Label' name='lbl16' id='lbl16' title="Vpliv  alkohola:" Tag='"_31_Vpliv_alkohola"' Top='2040' Left='12120'/>
                   <div type='Label' name='lbl17' id='lbl17' title="Prijavitelj  je 112:" Tag='"_29_Prijavitelj_je_112"' Top='600' Left='11520'/>
                   <div type='Label' name='lbl18' id='lbl18' title="Prijavitelj  je zdravstveni dispeèer:" Tag='"_29_Prijavitelj_je_ZdravstveniDisp"' Top='240' Left='10560'/>
                   <div type='Label' name='lbl19' id='lbl19' title="Prijavitelj  je zdravnik:" Tag='"_29_Prijavitelj_je_Zdravnik"' Top='7560' Left='6360'/>
                   <div type='Label' name='lbl20' id='lbl20' title="Prijavitelj  je policija:" Tag='"_29_Prijavitelj_je_Policija"' Top='7200' Left='6360'/>
                   <div type='Label' name='lbl21' id='lbl21' title="Prijavitelj  je oèividec:" Tag='"_29_Prijavitelj_je_Ocividci"' Top='6840' Left='6360'/>
                   <div type='Label' name='lbl22' id='lbl22' title="Število  oživljanj z odpustom iz bolnišnice, razdeljeno glede na CPC3-4:" Tag='"_18_St_Ozivljanje_Odpust_cpc34"' Top='2160' Left='5160'/>
                   <div type='Label' name='lbl23' id='lbl23' title="Število  intervencij z veè pacienti:" Tag='"_30_St_int_z_vec_pac"' Top='1680' Left='10800'/>
                   <div type='Label' name='lbl24' id='lbl24' title="Prijavitelj  je drugo:" Tag='"_29_Prijavitelj_je_Drugo"' Top='1320' Left='11760'/>
                   <div type='Label' name='lbl25' id='lbl25' title="Prijavitelj  je pacient sam:" Tag='"_29_Prijavitelj_je_PacientSam"' Top='960' Left='10920'/>
                   <div type='Label' name='lbl26' id='lbl26' title="Prijavitelj  je svojec:" Tag='"_29_Prijavitelj_je_Svojec"' Top='6480' Left='6360'/>
                   <div type='Label' name='lbl27' id='lbl27' title="Število  mrtvih ob prihodu:" Tag='"_28_St_mrtvih_ob_prihodu"' Top='6120' Left='6360'/>
                   <div type='Label' name='lbl28' id='lbl28' title="Število  pacientov pri katerih je bila uporabljena zunanja elektro konverzija:" Tag='"_27_St_elektro_konverzija"' Top='5640' Left='5160'/>
                   <div type='Label' name='lbl29' id='lbl29' title="Število  pacientov pri katerih je bila uporabljena zunanja elektro stimulacija:" Tag='"_26_St_zun_elektorstim"' Top='5160' Left='5160'/>
                   <div type='Label' name='lbl30' id='lbl30' title="Število  pacientov, ki so bili defibrilirani s strani prvih posredovalcev:" Tag='"_25_St_defibrilacij_Prvi_posredovalci"' Top='4680' Left='5160'/>
                   <div type='Label' name='lbl31' id='lbl31' title="Število  pacientov, ki so bili defibrilirani:" Tag='"_24_St_defibrilacij"' Top='4440' Left='5160'/>
                   <div type='Label' name='lbl32' id='lbl32' title="Število  posnetih 12 kanalnih EKG:" Tag='"_23_St_12_kanalnih_EKG"' Top='4080' Left='5160'/>
                   <div type='Label' name='lbl33' id='lbl33' title="Število  vzpostavljenih osalnih poti:" Tag='"_22_St_Intraosalnih_Poti"' Top='3720' Left='5160'/>
                   <div type='Label' name='lbl34' id='lbl34' title="Število  vzpostavljenih venskih poti:" Tag='"_21_St_Venskih_poti"' Top='3360' Left='5160'/>
                   <div type='Label' name='lbl35' id='lbl35' title="Število  uporabljenih supraglotiènih pripomoèkov:" Tag='"_20_Stevilo_uporabljenih_supragloticnih_pripomockov"' Top='3000' Left='5160'/>
                   <div type='Label' name='lbl36' id='lbl36' title="Število  endotrahealnih intubacij (vseh):" Tag='"_19_St_Endotrahealnih_intubacij"' Top='2640' Left='5160'/>
                   <div type='Label' name='lbl37' id='lbl37' title="Število  oživljanj z odpustom iz bolnišnice, razdeljeno glede na CPC1-2:" Tag='"_18_St_Ozivljanje_Odpust_cpc12"' Top='1680' Left='5160'/>
                   <div type='Label' name='lbl38' id='lbl38' title="Število  oživlj. z usp. vzpo. spont. krv. obt. s strani PP pred prihodom ekipe NMP:" Tag='"_17_St_Ozivl_s_Cirkul_Priv_posred"' Top='1200' Left='5160'/>
                   <div type='Label' name='lbl39' id='lbl39' title="Število  oživljanj z uspešno vzpostavitvijo spontanega krvnega obtoka:" Tag='"_16_St_ozivljanj_z_vzpostavitvijo_cirk"' Top='720' Left='5160'/>
                   <div type='Label' name='lbl40' id='lbl40' title="Število  oživljanj, ki so jih zaèeli prvi posredovalci:" Tag='"_15_Stevilo_ozivljanj_prvi_posred"' Top='240' Left='5160'/>
                   <div type='Label' name='lbl41' id='lbl41' title="frmStatistika.frx:0038" Tag='"_14_Stevilo_Ozivljanj"' Top='7440' Left='-120'/>
                   <div type='Label' name='lbl42' id='lbl42' title="Število  nepotrebnih intervencij:" Tag='"_13_Stevilo_nepotrebnih_intervencij"' Top='7080' Left='120'/>
                   <div type='Label' name='lbl43' id='lbl43' title="Število  pacientov, ki so ostali na kraju dogodka:" Tag='"_12_Stevilo_pac_ostali_na_kraju"' Top='6600' Left='120'/>
                   <div type='Label' name='lbl44' id='lbl44' title="Število  pacientov pripeljanih v druge zavode:" Tag='"_11_Stevilo_pac_v_druge_zavode"' Top='6120' Left='120'/>
                   <div type='Label' name='lbl45' id='lbl45' title="Število  pacientov pripeljanih v ANMP:" Tag='"_10_Stevilo_pacientov_prepeljanih_v_ANMP"' Top='5160' Left='120'/>
                   <div type='Label' name='lbl46' id='lbl46' title="Število  pacientov pripeljanih v bolnišnico:" Tag='"_09_Stevilo_pacientov_prepeljanih_v_UC"' Top='4680' Left='120'/>
                   <div type='Label' name='lbl47' id='lbl47' title="Število  pacientov v prometnih nesreèah:" Tag='"_08_Stevilo_Pacientov_v_prometnih"' Top='4320' Left='120'/>
                   <div type='Label' name='lbl48' id='lbl48' title="Število  pacientov:" Tag='"_07_Stevilo_Pacientov"' Top='3960' Left='0'/>
                   <div type='Label' name='lbl49' id='lbl49' title="Povpreèno  število opravljenih km na intervenciji:" Tag='"_06_Povprecno_stevilo_opr_km"' Top='3240' Left='120'/>
                   <div type='Label' name='lbl50' id='lbl50' title="Skupni  èas klic izhodišèe [ure:min:sek]:" Tag='"_05_Klic_VrnitevVIzhodice_v_sekundah"' Top='2880' Left='120'/>
                   <div type='Label' name='lbl51' id='lbl51' title="Povpreèni  odzivni èas prvih posredovalcev [ure:min:sek]:" Tag='"_03_Povprecni_odzivni_cas_PP"' Top='2040' Left='120'/>
                   <div type='Label' name='lbl52' id='lbl52' title="Povpreèni  odzivni èas (klic do prihod na kraj) [ure:min:sek]:" Tag='"_03_Povprecni_odzivni_cas_v_sekundah"' Top='1560' Left='120'/>
                   <div type='Label' name='lbl53' id='lbl53' title="Število  aktivacij prvih posredovalcev:" Tag='"_02_Stevilo_aktivacij_prvih_posredovalcev"' Top='1320' Left='120'/>
               </root>
End Module
