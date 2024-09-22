print("Hello World!")

def user():
    name = input("What is your name?: ")
    age = int(input("What is your age?: "))
    favorite_color = input("What is your favorite color?: ")
    favorite_movie = input("What is your favorite movie?: ")
    occupation = input("What is your occupation?: ")
    hobbies = input("What are your hobbies? (separate with commas): ").split(",")
    
    return {
        "name": name,
        "age": age,
        "favorite_color": favorite_color,
        "favorite_movie": favorite_movie,
        "occupation": occupation,
        "hobbies": [hobby.strip() for hobby in hobbies]  # Stripping whitespace
    }

user_info = user()
print(user_info)
