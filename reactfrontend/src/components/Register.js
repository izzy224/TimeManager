import {
  Center,
  Flex,
  Box,
  Heading,
  FormControl,
  FormLabel,
  Input,
  Button,
} from "@chakra-ui/react";
import React, { useState } from "react";

const Form = {
  Username: "",
  Email: "",
  Name: "",
  Surname: "",
  Password: "",
};
const Register = () => {
  const [registerData, setRegisterData] = useState(...Form);
  const [confirmPass, setConfirmPass] = useState("");

  const handleSubmit = (event) => {
    // var data = new FormData();
    // data.append("user", JSON.stringify(registerData));
    if()
    fetch("/api/register", {
      headers: { "Content-type": "application/json" },
      method: "POST",
      body: JSON.stringify(registerData),
    })
      .then((response) => response.json())
      .then((data) => console.log(data));
    event.preventDefault();
  };
  return (
    <>
      <Flex mt="5" width="full" justifyContent="center" alignItems="center">
        <Box
          p="8"
          maxWidth="1000px"
          borderWidth="1"
          borderRadius="12"
          boxShadow="lg"
        >
          <Box textAlign="center">
            <Heading>Login</Heading>
            <Box my="4" textAlign="left"></Box>
            <form onSubmit={handleSubmit}>
              {/* Username, Password, Email, Name, Surname */}
              <FormControl isRequired>
                <FormLabel>Username</FormLabel>
                <Input
                  type="text"
                  onChange={(event) =>
                    setRegisterData({
                      ...registerData,
                      Username: event.currentTarget.value,
                    })
                  }
                />
              </FormControl>
              <FormControl isRequired>
                <FormLabel>Email</FormLabel>
                <Input
                  type="email"
                  onChange={(event) =>
                    setRegisterData({
                      ...registerData,
                      Email: event.currentTarget.value,
                    })
                  }
                />
              </FormControl>
              <FormControl isRequired>
                <FormLabel>Name</FormLabel>
                <Input
                  type="text"
                  onChange={(event) =>
                    setRegisterData({
                      ...registerData,
                      Name: event.currentTarget.value,
                    })
                  }
                />
              </FormControl>
              <FormControl isRequired>
                <FormLabel>Surname</FormLabel>
                <Input
                  type="text"
                  onChange={(event) =>
                    setRegisterData({
                      ...registerData,
                      Surname: event.currentTarget.value,
                    })
                  }
                />
              </FormControl>
              <FormControl isRequired>
                <FormLabel>Password</FormLabel>
                <Input
                  type="password"
                  onChange={(event) =>
                    setRegisterData({
                      ...registerData,
                      Password: event.currentTarget.value,
                    })
                  }
                />
              </FormControl>
              <FormControl isRequired>
                <FormLabel>Confirm password</FormLabel>
                <Input
                  type="password"
                  onChange={(event) =>
                    setConfirmPass(event.currentTarget.value)
                  }
                />
              </FormControl>
              <Button width="full" mt={4} type="submit">
                Register
              </Button>
            </form>
          </Box>
        </Box>
      </Flex>
    </>
  );
};

export default Register;
