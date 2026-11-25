# GDIM 31 Final: 2D
## Devlogs
### Milestone 1
1) My cat's kick hitbox activated (the Console showed "KICK HITBOX ACTIVATED!" from KickAttack.OnEnable()), but it never printed "KICK HITBOX TOUCHED" from OnTriggerEnter2D, so I knew the problem was collision detection, not Player.Kick(). [What you checked first.]

2) In the Inspector, kick_right had a 3D Box Collider, but OnTriggerEnter2D only responds to 2D colliders. I replaced it on both hitboxes with a Box Collider 2D (Is Trigger checked) and shrank it to sit in front of the cat's feet. Then Kickable.Kick() applied AddForce(..., ForceMode2D.Impulse) and the box flew in the kick direction. [What you learned.]


### Milestone 2
TODO.

## Playtesting Reports
### Milestone 1
#### Report 1
Hi! I played your games for 5-10 minutes and I really like your decoration! However, I think the transition between the idles are kind of being delayed. You should change the transition duration to 0. Thank you!

#### Report 2
Hello! I played your game and I notice that the check box isn't checked when I kicked one of the items. I'm having the same problem on that too, so if you figure out how to fix that, it would be very generous of you to teach me how to fix it. Thank you!

### Milestone 2
#### Report 1
TODO.

#### Report 2
TODO.

## Open-Source Assets
- [Interior sprites](https://rcpstd.itch.io/interior-tileset-asset-pack-16x16)
- [Ninja cat sprites](https://opengameart.org/content/cat-fighter-sprite-sheet)
- [Food sprites](https://ghostpixxells.itch.io/pixelfood)
- [More food and item sprites](https://ipixl.itch.io/pixel-art-items-part-1)