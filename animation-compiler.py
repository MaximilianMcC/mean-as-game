from PIL import Image
import os

# Get the path to all of the animation frames
paths = os.listdir("./")


# Get all of the image
images = []
for path in paths:

	# Ignore anything that isn't a png
	if not path.endswith(".png"): continue
	
	# Load in the image
	images.append(Image.open(path))

# Make the image for the actual texture
frame_width = images[0].width
frame_height = images[0].height
animation = Image.new("RGBA", (frame_width * len(images), frame_height))

# Paste all of the image onto the
# new animation image thingy yk
for i in range(len(images) - 1):
	animation.paste(images[i], (frame_width * i, 0))

# Save the image
animation.save("animation.png")

# Yap sesh
print("Exported animation. Use a spacing offset thingy of", frame_width)