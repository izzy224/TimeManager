import { MoonIcon, SunIcon } from "@chakra-ui/icons";
import {
  Box,
  Flex,
  IconButton,
  useColorMode,
  Text,
  Button,
  Link as ChakraLink,
} from "@chakra-ui/react";
import React, { useState } from "react";
import { useNavigate, Link } from "react-router-dom";
const Navbar = () => {
  const { colorMode, toggleColorMode } = useColorMode();
  const nav = useNavigate();

  return (
    <>
      <Box mx="30px" borderBottom="2px">
        <Flex px="5" justifyContent="space-between">
          <ChakraLink as={Link} to="/">
            <Text textAlign="left" fontSize="lg">
              ResourceManager
            </Text>
          </ChakraLink>
          <Box>
            <Button onClick={() => nav("/login")} variant="ghost">
              Login
            </Button>
            <IconButton
              icon={colorMode === "light" ? <MoonIcon /> : <SunIcon />}
              onClick={toggleColorMode}
              variant="ghost"
            />
          </Box>
        </Flex>
      </Box>
    </>
  );
};

export default Navbar;
