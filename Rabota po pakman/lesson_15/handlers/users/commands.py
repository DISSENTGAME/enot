

from telebot.types import Message
from data.loader import bot


@bot.message_handler(commands=['start'], chat_types='private')
def start(message: Message):
    chat_id = message.chat.id
    first_name = message.from_user.first_name
    bot.send_message(chat_id, f"Привет, {first_name}")

