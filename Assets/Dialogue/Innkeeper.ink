VAR tomb_joe = 0
VAR ale_night_tosh = 0
VAR phillip_well = 0
VAR ale_angry = 0
VAR phillip_remains = 0
VAR doctor_rumors = 0
VAR brut_sighting = 0
VAR phillip_remains_found = 0

->Intro

==Intro==
Mr. Ale: Good evening Reverend, how can I help?
->Hub

==Hub==
+[(Leave) Thank you. God bless you.]->Leave
+{tomb_joe} [Who vandalized Joe's tomb?]->Joe_Tomb
+{ale_night_tosh} [Were you stealing from Phillip?]->Well
+[Have you seen anything interesting?]->Information
+[How is your family?]->Family

==Joe_Tomb==
Mr. Ale: Oh, the whole 'murderer' thing? No one knows who did it...
{ale_angry: (Mr. Ale doesn't seem interested in continuing the conversation.)}
    +   {ale_angry == 0}[But...?]
        Mr. Ale: But nothing, I don't like talking behind people's back or spreading rumors.
        Mr. Ale: ...That said... Joe wasn't very liked. He was the only barber in town, and a bloody good one at that, but he was also... difficult to be around.
        Mr. Ale: He also didn't grow up here. That didn't help.
    +   +   [Where was he from?]
            Mr. Ale: Supposedly he came from a city. Wanting a quiet life and all that. 
    +   +   +   ['Supposedly']
                Mr. Ale: Well... rumor has it he didn't chose to leave, and that's all I'll ellaborate. If you want to know more, you should talk to Greg or Brut. 
                Mr. Ale: I'm actually surprised someone put a headstone to begin with, we only found a some of his clothes in the woods.
                ~phillip_remains = 0
                Mr. Ale: Anything else I can help you with?
    -   -   -   ->Hub
    +   ->
        ->Hub

==Well==
Mr. Ale: No! Of course not!
    +   [Very well.] ->Hub
    +   [Tosh says he saw you.]
        Mr. Ale: Oh, that...
        Mr. Ale: Look, I wasn't stealing from Phillip. That well wasn't built by him, it belonged to his father and he never had any issue with letting me use it!
        Mr. Ale: I run a tavern, I can't spare an hour walk to the river every time I am going to to make a drink. 
        Mr. Ale: Oh, but Phillip would not let anyone use his precious well! That bloody fool...
            ~phillip_well = 0
    +   +   [Sounds like you are happy he's dead]
            Mr. Ale: Of course I'm not! But I wonder if this all started because he started throwing a fit at the wrong person.
    -   -   ->Hub
    +   +   [Did you kill him?]
            Mr. Ale: H-heavens, no! Are you insane? I am not that kind of innkeeper!
            (The accusation seems to have angered him.)
            ~ale_angry = 1
            ->Hub
    +   +   {phillip_remains_found}[I found a skeleton in the well.]
            Mr. Ale: Are you serious? Oh my god...
            Mr. Ale: He must have died in the woods, maybe the creature dumped him in the well after eating his flesh? 
            Mr. Ale: I have admittely used that water since he died, and it never tasted any differently.
            Mr. Ale: Anyway, did you find out something else about him?
    +   +   +   [No. But I have more questions.]
                Mr. Ale: Sure, go ahead.
    -   -   -   ->Hub
            

==Family==
Mr. Ale: The wife and son are doing fine. There's obviously no business today, so they're just cleaning the inn and such.
->Hub

==Information==
Mr. Ale: I have a believable and an incredible story. Which one would you like to hear?
    +   [The factual one.]->Realistic_Story
    +   [The unrealistic one.]->Unrealistic_Story

=Realistic_Story
Mr. Ale: The night Father Wright died, he had gathered all the women and children in the church, probably to see if someone still died that night. 
    +   [Well, someone did]
    Mr. Ale: Right, which is how we know that the creature is disguised as a man, because all the women and children were accounted for when he died, but none of the men. 
    Mr. Ale: Anyway, that's not the story, but rather that I saw Brut waiting behind the cemetery that night, and he doesn't have anyone that he could've been waiting for anymore.
    ~brut_sighting = 1
    Mr. Ale: Not an exciting story, anyway.
    +   +   [What about the other story?] ->Unrealistic_Story
    +   +   [Let me ask you something else.]
            Mr. Ale: Sure.
            ->Hub
    

=Unrealistic_Story
Mr. Ale: That doctor in the market? They say there's no man under those clothes. 
Mr. Ale: They also say if you catch a glimpse under the robes, you will notice there's nothing between the boots and the rest of the body. No legs at all.
~doctor_rumors = 1
+   [That seems like a nasty rumor]
        Mr. Ale: Perhaps. But he did hole up in an old house, and sometimes there's strange sounds coming from it.  
        Mr. Ale: Truth is also that Phillip died the same week the doctor moved in, so there's definitely some logic to the cautiousness.
+   +   [What about the other story?] ->Realistic_Story
+   +   [Let me ask you something else.]
        Mr. Ale: Sure.
-   -   ->Hub


==Leave==
Mr. Ale: Good luck.
.
->END