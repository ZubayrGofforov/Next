select * from users;


-- Delete FUNCTION
Create or replace Function DeleteUser(
       p_user_id VARCHAR2
) return VARCHAR2
IS 
  v_message VARCHAR2(100);
BEGIN
  DELETE from Users Where Id = p_user_id;
  v_message := 'User deleted successfully';
  return v_message;
Exception 
  WHEN NO_DATA_FOUND THEN 
    v_message := 'User not found';
    RETURN v_message;
  WHEN OTHERS THEN
    v_message := 'Error deleting user';
    RETURN v_message;
END DeleteUser;

BEGIN
    DBMS_OUTPUT.PUT_LINE(DeleteUser('0164713191F34CCA94AE2E8A1BE86BF3'));
END;


-- Delete PROCEDURE
CREATE OR REPLACE PROCEDURE DeleteUserProcedure(
    p_user_id IN VARCHAR2,
    o_message OUT VARCHAR2
)
IS
BEGIN
    DELETE FROM Users WHERE Id = p_user_id;
    IF SQL%ROWCOUNT = 1 THEN
        o_message := 'User deleted successfully';
    ELSE
        o_message := 'User not found';
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        o_message := 'Error deleting user';
END DeleteUserProcedure;

DECLARE
    v_message VARCHAR2(100);
BEGIN
    DeleteUserProcedure('84BB16457D4145F5B87A3F6C4AE511EC', v_message);
    DBMS_OUTPUT.PUT_LINE(v_message);
END;
