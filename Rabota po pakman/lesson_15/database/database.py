import psycopg2
from config import DB_USER, DB_HOST, DB_NAME, DB_PASSWORD

class DataBase:
    def __init__(self):
        self.database = psycopg2.connect(
            database=DB_NAME,
            user=DB_USER,
            password=DB_PASSWORD,
            host=DB_HOST 
        )
    
    def manager(self, sql, *args,
                fetchone:bool=False,
                fetchall:bool=False,
                fetchmany:bool=False,
                commit:bool=False):
        with self.database as db:
            with db.cursor() as cursor:
                cursor.execute(sql, args)
                if commit:
                    result = db.commit()
                elif fetchone:
                    result = cursor.fetchone()
                elif fetchall:
                    result = cursor.fetchall()
                elif fetchmany:
                    result = cursor.fetchmany()
            return result
