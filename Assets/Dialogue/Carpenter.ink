VAR tomb_joe = 1
VAR joe_rumors = 1
VAR greg_bloodstain = 0
VAR greg_bloodtrail = 0
VAR brut_daughter_killer = 0
VAR brut_stress_0 = 0
VAR brut_stress_1 = 0
VAR brut_stress_2 = 0
VAR _temp = 0


~_temp = 0
->Intro

==Intro==
Brut: What do you want?
->Hub

==Hub==
~_temp = brut_stress_0 + brut_stress_1 + brut_stress_2
{_temp > 2:
(Brut is nervous and avoiding conversation. I won't get anything out of him now.)
}
+ [(Leave) God bless you.] ->Leave
+ {_temp <= 2}[I'm sorry for your loss.]->Loss
+ {_temp <= 2}{tomb_joe> 0} [Joe's tomb is vandalized.]->Joe
+ {_temp <= 2}[Have you seen anything odd?]->Accusations

==Loss==
Brut: I don't need you pity.
+ [About your daughter's death...]->Maria
+ [About your wife's death...]->Victoria
+ [Very well, I have more questions.]->Intro


=Maria
Brut: You are either brave or a fool to ask me something like that. If you weren't a man of the cloth I would be-
~brut_stress_2 = 1
+ [Let's change the subject]->Hub

=Victoria
Brut: She killed herself.
+   [Didn't the monster kill her?]
    Brut: Sure, after she walked into the woods at midnight.
    Brut: She was devastated after what happened to Maria. Then, a week before her death, she suddenly went back to her old self.
    Brut: I lowered my guard, didn't notice she wasn't in the house until it was too late. I looked for her all night, but couldn't find her in time.
-   -   ->Victoria_2
=Victoria_2
+   +   [You were outside after midnight?]
        Brut: Didn't see any monsters, if that's what you're wondering. Was half expecting one to jump at me at any moment.
+   +   +   [Were you afraid of it?]->Victoria_3
+   +   +   [You don't believe in it?]->Victoria_3
+   +   [Was anyone else with you?]
        Brut: Father Wright was with me. Not that you can ask him now.
-   -   -   ->Victoria_2
+   +   [What did you find?]
        Brut: Father Wright was with me. He convinced me to go back to town eventually. As much as I hate to admit it, I would now be buried next to her if I hadn't.
        Brut: As soon as the sun came out we went back in with Greg and John. 
        Brut: She was so close... I might have even walked next to her the night before.
        Brut: She was mauled. It wasn't as bad as the others, though. Maybe Father Michael's pressence somehow scared the demon away halfway through...
        (Brut seems distraught by the memories of that day.)
        ~brut_stress_0 = 1
->Hub

=Victoria_3
Brut: I soiled my pants on the way home. There is no doubt in my christian heart that... something is out there. 
Brut: You can feel it in the air, the sounds of the night, the shivers on your skin. It's not only people that fear that thing.
->Victoria_2


==Joe==
Brut: Yeah, what about it.
    +{joe_rumors} [Did you do it?]
        Brut: Yes. 
    +   +   [Why?]
            Brut: Because he killed my little girl, that's why.
            Brut: Everyone blamed it on the demon or whatever, but we all heard the rumors about Joe. It's a bloody miracle it took him so long to do what he did.
            Brut: I just wish it hadn't been my family that paid the price. 
            ~brut_daughter_killer = 1
-   -   -   -   ->Joe_Interrogation
    +{joe_rumors == 0} [Do you know who did it?]
        Brut: Maybe. Joe wasn't well liked. 
        Brut: I am not going to tell on anyone, though.
        ->Hub
=Joe_Interrogation
    +   +   +   [Did you kill him?]
                Brut: I wish I had. I hesitated too long. Before I knew it, they found his clothes bloodied in the forest.
                Brut: For all we know he may have faked it all and is laughing at us somewhere else. That bloody bastard.
                ~_temp = brut_stress_0 + brut_stress_1 + brut_stress_2
                {_temp > 1:
                (Brut is visible nervous as he says this.)
                }
                ->Joe_Interrogation
    +   +   +   [Do you have proof of this?]
                Brut: His business was closed that entire day. Didn't think much of it. But then it started to get dark, and Maria wasn't back from playing with Ale's son...
                Brut: If only I had paid him a visit...
                (Brut seems distraught by the memories of that day.)
                ~brut_stress_1 = 1
                ->Joe_Interrogation
    +   +   +   [Do you think he was the demon?]
                Brut: He was a monster. 
                Brut: But, well, Father Wright died last month, so he can't be THE monster, right?
                ~_temp = brut_stress_0 + brut_stress_1 + brut_stress_2
                {_temp > 1:
                (Brut is visible nervous as he says this.)
                }
                ->Joe_Interrogation
    +   +   +   [I have other questions.] 
                Brut: Be quick.
                ->Hub


==Accusations==
Brut: That bloody doctor. There is something odd about him. He talks as if he's better than us, and showed up the same week Phillip died. 
+   [But?]
    Brut: But he has an allibi for most deaths. Father Wright vouched for him on two occassions, Mr. Ale on two, Joe once.
    Brut: Still, I don't trust him. There is something wrong about him...
    ->Hub

==Leave==
Brut: Whatever.
->END