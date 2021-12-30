VAR tosh_skull = 0
VAR smith_squirrel = 0
VAR brut_night_tosh = 0
VAR ale_night_tosh = 0

->Intro

==Intro==
Tosh: Hi.
->Hub

==Hub==
+[God bless you (Leave)] ->Leave
*[I see you dug a new hole.] ->Hole
*{tosh_skull} [Couldn't help but notice there is a human skull in your house.] ->Skull
+[Have you seen anything... interesting lately?] ->Suspicious
*[You left the door to your house open.] ->House

==Hole==
Tosh: Full moon tonight.
    *[I appreciate the confidence.]
        Tosh: You're welcome.
        ->Hub
    *[We won't need it once I catch the demon.]
        Tosh: Then you will need a hole for it.
        ->Hub


==Skull==
Tosh: Mama's.
    *[Excuse me?]
    Tosh: She said she would always look over me.
        -*[So you dug her up?]
            Tosh: Yes.
            (He stares at me with a blank expression. I drop the topic.)
            ->Hub


==House==
(Tosh looks briefly at his cabin, then goes back to shoveling. Seemingly undisturbed by this information.)
->Hub


==Suspicious==
Tosh: When?
    *[Morning.]
    ->Suspicious_Morning
    *[Afternoon.]
    ->Suspicious_Afternoon
    +[Evening]
    ->Suspicious_Evening
    +[Nevermind]
    Tosh: Something else?
    ->Hub

==Suspicious_Morning==
~smith_squirrel = 1
Tosh: Smith Jr killed a squirrel last week.
    +   [By accident?]
        Tosh: He dropped a rock on it.
    +   [Uh... anything else?]
    
-   Tosh: I sleep in the morning. I don't see much.
-   +[What about another time of the day?]
    ->Suspicious
    


==Suspicious_Afternoon== 
Tosh: No
+[What about another time of the day?]
->Suspicious

==Suspicious_Evening==
Tosh: I saw Brut leave his house on Monday.
*   [Where was he going?]
    Tosh: Dunno, lost him.
    ~brut_night_tosh = 1
    ->Ale_Story
    
+    ->Ale_Story
    
    =Ale_Story
    Tosh: I also saw Mr Ale go behind Joe's house the night before he died. Probably to use his well. Joe hated that.
    ~ale_night_tosh = 1
    Tosh: Can't think of anything else.
    ++  [What about another time of the day?]
    --   ->Suspicious

==Leave==
(Tosh nods and goes back to digging)
->END