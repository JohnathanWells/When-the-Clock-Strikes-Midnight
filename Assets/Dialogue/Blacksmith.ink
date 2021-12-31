VAR smith_squirrel = 0
VAR smith_angry = 0
VAR monster_alone = 0
VAR monster_midnight = 0
VAR smith_sarah_midnight = 0

->Intro

==Intro==
John Smith: Hello Father. Tell me how can I help you so we can all go back inside.
->Hub

==Hub==
+{smith_angry == 0}[How is your son doing?] ->Son
+[Anything suspicious these last couple of months?] ->Suspicious
+[(Leave) Nothing for now. Stay outside.]->Leave

==Son==
John Smith: Bloody bored of being stuck inside all day. 
    +{smith_squirrel}[Tosh says he saw your kid kill a squirrel the other day.] ->Son_Squirrel
    
    +   [It's for his own good.]
        John Smith: I fail to see how isolating my kid will protect him. Joe, Sarah, and Father Wright were all inside and alone when the monster got them.
        ~monster_alone = 3
        John Smith: If anything you are putting him more at risk.
        ++  [I'll think about it. Let's talk about something else.]
            John Smith: Like what? 
            ->Hub
        ++ [Talking about Sarah...] ->Son_Mother
    +   [My condolences for your wife.] ->Son_Mother
    
=Son_Mother
John Smith: Yeah...
    +   [What happened that night?]
        John Smith: She, the kid, and I... had a fight. I went to get drunk at the tavern, Junior came to get me when it started to get dark.
        John Smith: We hung out for a couple of hours while we cooled down and made up. When we came back home it was already past midnight and Sarah was...
        John Smith: Sorry Father, can we talk about something else?
        { smith_sarah_midnight == 0:
        ~monster_midnight++
        ~smith_sarah_midnight = 1
        }
        ->Hub
    
=Son_Squirrel
John Smith: Tosh can go to hell. 
+[Is it true?]
-John Smith: ...Yes. He does that sometimes. To squirrels, rats, stray cats...
    ++[People?]
    --John Smith: Heavens, no! Only animals, he's too small to hurt a person, even if he wanted to.
    
        +++[Would he do it if he was bigger?]
            John Smith: We're done talking about my son. 
            (He seems visibly angry now.) 
            ~smith_angry = 1
            ->Hub
        
        +++[(Drop topic) I see. Let's talk about something else.]
            ---John Smith: Whatever I need to do to get back inside.
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

==Leave==
John Smith: Fine.
.
->END