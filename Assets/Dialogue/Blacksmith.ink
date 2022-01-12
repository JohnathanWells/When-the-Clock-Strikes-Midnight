VAR smith_squirrel = 0
VAR smith_hermit = 0
VAR smith_angry = 0
VAR monster_alone = 0
VAR monster_midnight = 0
VAR smith_Ann_midnight = 0
VAR church_letter = 0
VAR doctor_wife = 0
VAR tosh_skull = 0
VAR claw_marks = 0
VAR ale_night_tosh = 0
VAR brut_angry = 0
VAR town_anger = 0
VAR ale_angry = 0
VAR tosh_angry = 0

->Intro

==Intro==
John Smith: Hello Father. Tell me how can I help you so we can all go back inside.
->Hub

==Hub==
+[(Leave) Nothing for now. Stay outside.]->Leave
+{smith_angry == 0}[How is your son doing?] ->Son
+[Anything suspicious these last couple of months?] ->Suspicious
+[I'm sorry for your loss.]->Son_Mother
*{church_letter>0}[Do you recognize this letter?] ->Letter
*{claw_marks}[What are the marks on your neighbor's door]->Claws

==Son==
John Smith: Bloody bored of being stuck inside all day. 
    +{smith_squirrel}[Tosh says he saw him kill a squirrel the other day.] ->Son_Squirrel
    *{smith_hermit}[They say he has been reclusive lately.]
        John Smith: He has been taking the death of his mother pretty harshly.
    +   +   [My condolences...]->Son_Mother
    +   [It's for his own good.]
        John Smith: I fail to see how isolating my kid will protect him. Ann and Phillip were both inside their houses and alone when the monster got them.
        ~monster_alone = 2
        John Smith: If anything you are putting him more at risk.
        ++  [I'll think about it. Let's talk about something else.]
            John Smith: Like what? 
            ->Hub
        ++ [Talking about Ann...] ->Son_Mother
    +   [My condolences for your wife.] ->Son_Mother
    
=Son_Squirrel
John Smith: Tosh can go to hell. 
+[Is it true?]
-John Smith: ...Yes. He does that sometimes. To squirrels, rats, stray cats...
~smith_squirrel = 2
    ++[People?]
    --John Smith: Heavens, no! Only animals, he's too weak to hurt a person, even if he wanted to.
    
        +++[Would he do it if he was bigger?]
            John Smith: We're done talking about my son. 
            (He seems visibly angry now.) 
            ~smith_angry = 1
            ->Hub
        
        +++[I see. Let's talk about something else.]
            ---John Smith: Whatever I need to do to get back inside.
            ->Hub
    
==Son_Mother==
John Smith: Yeah...
    +   [What happened that night?]
        John Smith: The three of us... had a fight. I went to get drunk at the tavern, Junior came to get me when it started to get dark.
        John Smith: We hung out for a couple of hours while we cooled down and made up. When we came back home it was already past midnight and Ann was...
        John Smith: Sorry Father, can we talk about something else?
        { smith_Ann_midnight == 0:
        ~monster_midnight++
        ~smith_Ann_midnight = 1
        }
        ->Hub

==Suspicious==
John Smith: I usually work here during the afternoon, so I can't say I've seen anything then.
    +   [Nevermind, then]
        ->Hub
    +   [What about the rest of the day?] ->Suspicious_2

=Suspicious_2
John Smith: You should talk to Gregory about the morning, he's up before any of us to work on his farm.
John Smith: Mr Ale can tell you more about the evenings.
John Smith: Can't really say I've noticed anything particularly strange. Things are normal. Well, mostly normal if you ignore the paranoia.
->Hub

==Letter==
John Smith: No. Why would you even think it is mine?
+   [Not a lot of literate married men here]
    John Smith: The doctor is married, I saw his wedding ring once. He may a better candidate if you ask me. And you are asking me.
    ~doctor_wife = 1
+   +   [Thank you.]
        John Smith: Yeah.
        ->Hub


==Claws==
John Smith: Huh? On the Loom house? They weren't there last we checked.
+   [When is that?]
    John Smith: I don't know... the day after Ann died?
    John Smith: Never seen clawing marks anywhere else either. Maybe someone carved them to distract you?
    ->Hub

==Leave==
John Smith: Fine.
.
~town_anger = 0
{tosh_angry:
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
{ale_angry:
~town_anger++
}
->END