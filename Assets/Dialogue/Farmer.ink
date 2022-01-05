VAR greg_bloodstain = 0
VAR greg_bloodtrail = 0
VAR greg_skull = 0
VAR church_letter = 0
VAR joe_rumors = 0
VAR tomb_joe = 0
VAR annoyance = 0
VAR doctor_rumors = 0
VAR smith_hermit = 0
VAR brut_drinking = 0
VAR town_anger = 0

->Intro

==Intro==
Greg the Farmer: Blessed evening Father, how can I help you?
->Hub

==Hub==
+[(Leave) May God be with you.]->Leave
+{(greg_bloodstain or greg_bloodtrail)}[There's blood behind your house.]->Bloodstains_1
+{greg_skull==1}[There is a small skull in your fields.]->Skull
+{church_letter==2}[Can we go over the letter again?]
    Greg the Farmer: Sure thing, Father.
    ->Letter
//+{church_letter==5}[You lied to me about the letter]->Bloodstains_3
+{joe_rumors or tomb_joe}[Do you know who vandalized Joe's tomb?]->Joe_Tomb
+[How is your family?]->Family
+[Have you seen anything strange?]->Strange

==Bloodstains_1==
Greg the Farmer: Huh, is it still there? I thought the rain would've washed it away by now. One of the chickens gave me a hell of a fight.
+   [That looked like a lot of blood for a chicken]
    Greg the Farmer: Clearly you haven't slayed a chicken before!
    ->Hub
+   {church_letter} [This letter points to it.]
    ->Bloodstains_2

==Bloodstains_2==
Greg the Farmer: I can't say I understand a word in that piece of paper, could you read it out to me? 
+   [(Read letter out loud.)]
    Greg the Farmer: I see... And you say there's no signature or destination? Well, I don't know why it would point to my shed, but...
    ->Letter
    
//==Bloodstains_3==
//Greg the Farmer: Pardon me?
//+   [(One use.) You can read. The Doctor told me.]
//    Greg the Farmer: The implications of your words are severe, Father. Who would I even such a letter to?
//+   +   [One of the wives]
//        Greg the Farmer: And who would that be? Ask every single 
//        ->END
//+   +   [One of the men]
//+   [Nevermind, I'll get back with news later.]
//    Greg the Farmer: Ah, very well.
//    ->Hub
    
    
    
==Letter==
    Greg the Farmer: It's a letter mentioning a wife, so its sender is a married man that can write. 
    Greg the Farmer: Joe and Father Wright were the only single men in town. I have never seen that weird doctor with a wife either.
    Greg the Farmer: Brut and I don't know how to write, and neither do our kids.
    Greg the Farmer: Which only leaves Mr Ale and John Smith.
    {church_letter==1:Greg the Farmer: As to who it's for, I have no idea. Let me know if you find out anything.}
    ~church_letter = 2
    ->Hub

==Skull==
Greg the Farmer: Sorry Father, I really don't know who it belongs to. I had never noticed before. Please point me to it and we can give it a proper burial tomorrow.
~greg_skull = 2
->Hub

==Joe_Tomb==
Greg the Farmer: Oh, that... 
Greg the Farmer: Well... Joe had quite the reputation. It was only rumors, so no one did anything about it, but after all this started with Phillip those rumors sounded more... dangerous.
Greg the Farmer: I don't think Joe was a murderer, at least not in his time here, but he's as likely to be responsible for some of the deaths as he is not.
Greg the Farmer: That is all I will say on the matter. 
~joe_rumors = 1
->Hub

==Family==
Greg the Farmer: They're doing fine, for the most part. Don't like being stuck in the house, but I think they understand why it's being done.
->Hub

==Strange==
Greg the Farmer: Well, I don't like saying bad things about anyone... But...
Greg the Farmer: I'm almost sure I saw Tosh digging something up from the graveyard the other day.
Greg the Farmer: Brut has been drinking heavily since he lost his wife and kid. 
~brut_drinking = 1
Greg the Farmer: Smith Jr. barely leaves his house since his mom died. A weird kid, that one is.
~smith_hermit = 1
Greg the Farmer: That doctor in the market gives me the creeps. There's some rumors about him, you might want to ask Mr. Ale about them.
~doctor_rumors = 1
Greg the Farmer: That is all.
->Hub

==Leave==
{greg_skull or (greg_bloodstain and greg_bloodtrail):
    <>Greg the Farmer: Be careful out there, Father.
-else:
    <>Greg the Farmer: Amen, Father.
}
.
~town_anger = 0
{tosh_skull:
~town_anger++
}
{smith_angry:
~town_anger++
}
{brut_angry:
~town_anger++
}
{church_letter > 1:
~town_anger++
}
->END