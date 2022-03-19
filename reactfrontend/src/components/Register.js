import {
  Center,
  Flex,
  Box,
  Heading,
  FormControl,
  FormLabel,
  Input,
  Button,
  Link as ChakraLink,
} from "@chakra-ui/react";
import { Navigate, Link } from "react-router-dom";
import React, { useState } from "react";
import ErrorMessage from "./ErrorMessage";
const form = {
  Username: "",
  Email: "",
  Name: "",
  Surname: "",
  Password: "",
};
const Register = () => {
  const [registerData, setRegisterData] = useState({ ...form });
  const [confirmPass, setConfirmPass] = useState("");
  const [errors, setErrors] = useState([]);
  const [success, setSuccess] = useState(false);
  const handleSubmit = (event) => {
    if (confirmPass === registerData.Password) {
      fetch("/api/register", {
        headers: { "Content-type": "application/json" },
        method: "POST",
        body: JSON.stringify(registerData),
      })
        .then((response) => response)
        .then((data) => {
          if (data.status == 200) {
            setSuccess(true);
            setRegisterData(form);
          } else {
            var tempErr = [data.title];
            for (var err in data.errors) {
              tempErr = [...tempErr, data.errors[err][0]];
            }
            setErrors(tempErr);
          }
        });
    }
    event.preventDefault();
  };
  if (success) {
    return <Navigate to="/login" />;
  }

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
            <Heading>Register</Heading>
            <Box my="4" textAlign="left"></Box>
            <form onSubmit={handleSubmit}>
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
          {errors.length != 0 ? (
            errors.map((err) => {
              return <ErrorMessage message={err} />;
            })
          ) : (
            <></>
          )}
          <Center>
            <ChakraLink as={Link} to="/login">
              Already have an account?
            </ChakraLink>
          </Center>
        </Box>
      </Flex>
    </>
  );
};

export default Register;
