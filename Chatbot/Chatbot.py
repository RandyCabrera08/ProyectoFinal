import re
import random
from responses import questions_and_responses  # Importa preguntas y respuestas

def get_response(user_input):
    split_message = re.split(r'\s|[,:;.?!-_]\s*', user_input.lower())
    response = check_all_messages(split_message)
    return response

def message_probability(user_message, recognized_words, single_response=False, required_words=[]):
    message_certainty = 0
    has_required_words = True

    for word in user_message:
        if word in recognized_words:
            message_certainty += 1

    percentage = float(message_certainty) / float(len(recognized_words))

    for word in required_words:
        if word not in user_message:
            has_required_words = False
            break

    if has_required_words or single_response:
        return int(percentage * 100)
    else:
        return 0

def check_all_messages(message):
    highest_prob = {}

    def response(bot_response, list_of_words, single_response=False, required_words=[]):
        nonlocal highest_prob
        highest_prob[bot_response] = message_probability(
            message, list_of_words, single_response, required_words)

    # Ahora definimos las respuestas utilizando la función `response`
    for item in questions_and_responses:  # Iterar sobre las preguntas y respuestas
        response(
            item['response'],
            item['recognized_words'],
            item.get('single_response', False),
            item.get('required_words', [])
        )

    best_match = max(highest_prob, key=highest_prob.get)
    return unknown() if highest_prob[best_match] < 1 else best_match

def unknown():
    response = ['¿Puedes decirlo de nuevo?', 'No estoy seguro de lo que quieres decir.', 'Búscalo en Google a ver qué tal.'][random.randrange(3)]
    return response

while True:
    print("Bot: " + get_response(input('You: ')))
