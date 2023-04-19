from telebot import TeleBot
from config import TOKEN
from database.database import DataBase
db = DataBase()

bot = TeleBot(TOKEN)

