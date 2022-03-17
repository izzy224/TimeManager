import { MoonIcon, SunIcon } from "@chakra-ui/icons";
import { Box, Flex, IconButton, useColorMode, Text } from "@chakra-ui/react";
import React from "react";
const Navbar = () => {
  const { colorMode, toggleColorMode } = useColorMode();
  return (
    <>
      <Box mx="10px" borderBottom="2px">
        <Flex px="5" justifyContent="space-between">
          <Text fontSize="lg">TimeManager</Text>
          <IconButton
            icon={colorMode === "light" ? <MoonIcon /> : <SunIcon />}
            onClick={toggleColorMode}
            variant="ghost"
          />
        </Flex>
      </Box>
    </>
  );
};

export default Navbar;
