VAR player_feels_skeptical = false
VAR player_has_key = false

-> Outside_Store

=== Outside_Store ===
The weathered sign above the door reads "The Enchanted Pages." Vines cling stubbornly to the brick walls, and faint magical light seeps through the bookstore's windows.


* ["I can't believe she left me this place... what was she thinking?"] -> Response_1
* ["This place always felt... strange. But now it’s mine."] -> Response_2
* ["*Sigh* Alright, let’s see what Aunt Clara got me into this time."] -> Response_3
* ["Maybe I should just... walk away. This is too much."] -> Response_4

=== Response_1 ===
Running a magical bookstore? You’re barely keeping yourself together, let alone managing an entire shop.
~ player_feels_skeptical = true

-> Enter_Store

=== Response_2 ===
Even as a kid, you felt like the books were watching you... though Aunt Clara insisted it was “just the magic.”
-> Enter_Store

=== Response_3 ===
You grab the old key from your pocket, its cool metal grounding you. There's no turning back now.
-> Enter_Store

=== Response_4 ===
Walking away sounds tempting... but something deep inside tells you this place is meant for you.
-> Enter_Store

=== Enter_Store ===

You push the door open. It groans in protest before giving way, and you step inside.

The shelves stretch into shadowed corners, stacked with books of every size and color. Some seem to shimmer faintly when you aren’t looking directly at them.

* ["What... What is this place?"] -> Response_5
* ["I must be dreaming. Books don’t talk."] -> Response_6
* ["Is this some weird prank?"] -> Response_7
* ["Did Aunt Clara... know this would happen?"] -> Response_8

=== Response_5 ===
The Book of Beginnings: "This is *The Enchanted Pages*, your legacy. A place where stories come alive... and so will your destiny."
-> Next_Step

=== Response_6 ===
The Book of Beginnings: "Doubt all you like, but the magic here is very real... and very much yours now."
-> Next_Step

=== Response_7 ===
The Book of Beginnings: "A prank? Hardly. Your Aunt Clara trusted you to keep this place safe... and discover its secrets."
-> Next_Step

=== Response_8 ===
The Book of Beginnings: "Your aunt prepared for this moment long before you arrived. Everything is unfolding as it should."
-> Next_Step

=== Next_Step ===
Suddenly, the book flips its pages rapidly until it reveals a glowing map marked: **The Hidden Chamber.**

-> DONE
