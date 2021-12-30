"Hello Father, how can I help?"
->Hub

==Hub==
+[How is the family doing?] -> Family
+[Is the weather treating you okay?] -> Outside
+[Test dialogue] -> Test
+[That's all]
    -"Alright, see you father."
    ->END
    


==Family==
"Arlo and the wife are not happy to be stuck inside, but I'll take my chances."
-> Hub

==Outside==
"It's a little colder than usual, but not too bad.
+[How are the crops doing?]
    -"Nothing to complain."
    -"Green and plentiful"
+[Are you the killer?]
    -No
->Hub

==Test==
"Esternocleidomastoideo"
->Hub

-> END