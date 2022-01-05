VAR tosh_skull = 0
VAR tosh_father = 0
VAR smith_squirrel = 0
VAR brut_night_tosh = 0
VAR ale_night_tosh = 0
VAR tomb_joe = 0
VAR wright_plan = 0
VAR smith_angry = 0
VAR brut_angry = 0
VAR church_letter = 0
VAR town_anger = 0

->Intro

==Intro==
(Tosh looks at me but says nothing.)
->Hub

==Hub==
+[(Leave) May God be with you.] ->Leave
+[Have you seen anything lately?] ->Suspicious
*{tosh_skull} [Couldn't help but notice there is a human skull in your house.] ->Skull
+{tosh_father} [It sounds like you and the previous priest were close.]
    Tosh: Like a father to me.
    ->Wright_Relationship
+{tomb_joe} [Someone vandalized Joseph's tomb.]->Joe_Tomb
*[You left the door to your house open.] ->House
+[I see you dug a new hole.] ->Hole

==Hole==
Tosh: Full moon tonight.
    *[I appreciate the confidence.]
        Tosh: You're welcome.
        ->Hub
    *[We won't need it once I catch the demon.]
        Tosh: Then you will need a hole for it.
        ->Hub
    +[Is the phase of the moon related?]
    Tosh: Sometimes.
    ->Hub


==Skull==
Tosh: Father Wright's.
    *[Excuse me?]
    Tosh: He said he would always look over me.
        -*[So you dug him up?]
            Tosh: Yes.
            (He stares at me with a blank expression.)
            ~tosh_father = 1
            ->Hub

==Wright_Relationship==
    *   [I'm sorry for your loss, but you shouldn't exhume corpses.]
        (Tosh stares at me, then nods silently. He doesn't mean it.)
        ~tosh_father = 2
        ->Hub
    +   [What can you tell me about that night?]
        Tosh: The children and women were in church for a special midnight sermon. His idea.
        ~wright_plan = 1
    +   +   [What about the men?]
            Tosh: I kept guard outside so no one came in or out until morning. His orders. 
            Tosh: I found him at dawn.
            ->Wright_Night_Questions
=Wright_Night_Questions
    +   +   +   [Did anyone try to get in or out that night?]
                Tosh: Not after midnight. No one did.
                ->Wright_Night_Questions
    +   +   +   [Was anyone helping you that night?]
                Tosh: Don't know. Father Wright didn't say.
                ->Wright_Night_Questions
    +   +   +   [What did you find?]
                Tosh: Most where you are. Rest over there.
                Tosh: Put him together and buried him. Farmer asked if I had seen him, told him he died.
                ->Wright_Night_Questions
    +   +   +   [I'm sorry to hear that.]
                Tosh: Yes.
    -   -   -   ->Hub
            


==Joe_Tomb==
Tosh: Yes.
    +   [Do you know who it was?]
        Tosh: Ask Mr. Ale.
        ->Hub

==House==
(Tosh looks briefly at his cabin, then goes back to shoveling. Seemingly undisturbed by this information.)
->Hub


==Suspicious==
Tosh: When?
    +[Nevermind]
    Tosh: Something else?
    ->Hub
    *[Morning.]
    ->Suspicious_Morning
    *[Afternoon.]
    ->Suspicious_Afternoon
    +[Evening]
    ->Suspicious_Evening

==Suspicious_Morning==
~smith_squirrel = 1
Tosh: Smith Jr killed a squirrel last week.
    +   [By accident?]
        Tosh: He dropped a rock on it.
    +   [Uh... anything else?]
    
-   Tosh: I sleep in the morning. Don't see much then.
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
    Tosh: I also saw Mr Ale go behind Phillip's house the night before he died. Probably to use his well. Joe hated that.
    ~ale_night_tosh = 1
    Tosh: Can't think of anything else.
    ++  [What about another time of the day?]
    --   ->Suspicious

==Leave==
(Tosh nods.)
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